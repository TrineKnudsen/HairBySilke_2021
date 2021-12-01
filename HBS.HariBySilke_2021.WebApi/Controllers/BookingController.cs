using System;
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
        public ActionResult<AppointmentDto> CreateAppointment([FromBody] AppointmentDto appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Something went wrong");
            }
            var appointmentModel = new Appointment
            {
                TreatmentName = appointment.TreatmentName,
                Start = appointment.Start,
                Customer = new Customer
                {
                    Name = appointment.Customer.Name,
                    Email = appointment.Customer.Email,
                    PhoneNumber = appointment.Customer.PhoneNumber
                }
            };
            return Created($"https//:localhost/api/booking",_bookingService.BookAppointment(appointmentModel));
        }
        
        [HttpGet]
        public ActionResult<AppointmentDto> ReadAll()
        {
            try
            {
                var treatments = _bookingService.GetAllAppointments()
                    .Select(t => new AppointmentDto()
                    {
                        TreatmentName = t.TreatmentName,
                        Start = t.Start,
                        Customer = new CustomerDTO
                        {
                            Email = t.Customer.Email,
                            Name = t.Customer.Name,
                            PhoneNumber = t.Customer.PhoneNumber
                        }
                    }).ToList();
                return Ok(new AppointmentDtos()
                {
                    List = treatments
                });

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}