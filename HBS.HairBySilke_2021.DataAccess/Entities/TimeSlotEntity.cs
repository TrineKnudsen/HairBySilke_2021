using System;

namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class TimeSlotEntity
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        public string DayOfWeek { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}