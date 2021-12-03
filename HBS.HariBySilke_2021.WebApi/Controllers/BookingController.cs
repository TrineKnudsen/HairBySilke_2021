using System;
using System.Collections.Generic;
using System.Linq;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HBS.HariBySilke_2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public ActionResult<AppointmentDto> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var appointment = _bookingService.BookAppointment(new Appointment
            {
                TreatmentName = appointmentDto.TreatmentName,
                Start = appointmentDto.Start,
                Customer = new Customer
                {
                    Name = appointmentDto.Customer.Name,
                    Email = appointmentDto.Customer.Email,
                    PhoneNumber = appointmentDto.Customer.PhoneNumber
                }
            });
            var appDtoToReturn = new AppointmentDto
            {
                Start = appointment.Start,
                TreatmentName = appointment.TreatmentName,
                Customer = new CustomerDTO
                {
                    Email = appointment.Customer.Email,
                    Name = appointment.Customer.Name,
                    PhoneNumber = appointment.Customer.PhoneNumber
                }
            };
            
            return Created($"https//:localhost/api/booking",appDtoToReturn);
        }

        /*[HttpGet]
        public ActionResult<AppointmentDtos> GetAllApp()
        {
            try
            {
                var apps = _bookingService.GetAllApp()
                    .Select(p => new AppointmentDto()
                    {
                        Start = p.Start,
                        TreatmentName = p.TreatmentName,
                        Customer = new CustomerDTO
                        {
                            Name = p.Customer.Name,
                            Email = p.Customer.Email,
                            PhoneNumber = p.Customer.PhoneNumber
                        }
                    })
                    .ToList();
                
                return Ok(new AppointmentDtos
                {
                    List = apps
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }*/

        [HttpGet]
        public ActionResult<AppointmentDtos> ReadDailyApp(string dayOfWeek)
        {
            var dailyApp = _bookingService.GetDailyApp(dayOfWeek)
                    .Select(a => new AppointmentDto
                    {
                        Start = a.Start,
                        TreatmentName = a.TreatmentName
                    }).ToList();
            return Ok(new AppointmentDtos
            {
                List = dailyApp
            });
        }
        
    }
}