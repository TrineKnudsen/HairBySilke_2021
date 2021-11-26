using System;
using Itenso.TimePeriod;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class TimeSlotDto
    {
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
    }
}