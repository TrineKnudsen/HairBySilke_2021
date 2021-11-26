using System;
using Itenso.TimePeriod;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class TimeSlotDto
    {
        public string Start { get; set; }
        public double Duration { get; set; }
        
        public string DayOfWeek { get; set; }
    }
}