using System;
using System.Linq;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HBS.HariBySilke_2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }
        
        [HttpGet]
        public ActionResult<TimeSlotDto> ReadAll()
        {
            try
            {
                var timeSlots = _timeSlotService.GetAvailableTimeSlots()
                    .Select(t => new TimeSlotDto
                    {
                        DayOfWeek = t.Start.DayOfWeek.ToString(),
                        Start = t.Start,
                        Duration = t.Duration.TotalMinutes,

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

        [HttpGet("{duration:double}")]
        public ActionResult<TimeSlotsDto> GetAvailableTimeslotsByTreatment(double duration)
        {
            var list = _timeSlotService.GetAvailableTimeSlotsByTreatment(duration)
                .Select(t => new TimeSlotDto
                {
                    Duration = t.Duration.TotalMinutes,
                    Start = t.Start,
                    DayOfWeek = t.Start.DayOfWeek.ToString()

                }).ToList();

            return Ok(new TimeSlotsDto
            {
                List = list
            });
        }
    }
}