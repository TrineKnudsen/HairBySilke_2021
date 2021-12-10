using System;
using System.Collections.Generic;
using System.Linq;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
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
                Id = appointment.Id,
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
        
        [HttpGet]
        public ActionResult<AppointmentDtos> GetAllApp()
        {
            try
            {
                var apps = _bookingService.GetAllApp()
                    .Select(p => new AppointmentDto()
                    {
                        Id = p.Id,
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
        }

        [HttpPut("{appointmentIdToUpdate}")]
        public ActionResult<AppointmentDto> UpdateAppointment(int appointmentIdToUpdate, [FromBody] AppointmentDto appointmentDto)
        {
            var appointment = _bookingService.UpdateAppointment(appointmentIdToUpdate, new Appointment
            {
                Id = appointmentIdToUpdate,
                Start = appointmentDto.Start,
                TreatmentName = appointmentDto.TreatmentName
            });

            var newAppointmentDto = new AppointmentDto
            {
                Id = appointmentIdToUpdate,
                TreatmentName = appointment.TreatmentName,
                Start = appointment.Start,
                
            };
            return Ok(newAppointmentDto);
        }

        [HttpDelete("{id}")]
        public void DeleteAppointment(int id)
        {
            _bookingService.DeleteAppointment(id);
        }


    }
}