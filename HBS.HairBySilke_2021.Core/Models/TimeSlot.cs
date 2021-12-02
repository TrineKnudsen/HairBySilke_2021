using System;

namespace HBS.HairBySilke_2021.Core.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        public string DayOfWeek { get; set; }
        
        public bool IsAvailable { get; set; }

        public Appointment Appointment { get; set; }
    }
}