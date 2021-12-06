using System;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class TimeSlotDto
    {
        public DateTime Start { get; set; }
        public double Duration { get; set; }
        public string DayOfWeek { get; set; }
    }
}