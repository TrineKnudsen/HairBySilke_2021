using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBS.Domain.Services;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public ActionResult<TimeSlotDto> ReadAll()
        {
            try
            {
                var timeSlots = _bookingService.GetAvailableTimeSlots()
                    .Select(t => new TimeSlotDto
                    {
                        Start = t.Start,
                        Duration = t.Duration
                    })
                    .ToList();
                return Ok(new TimeSlotsDto
                {
                    List = timeSlots
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}