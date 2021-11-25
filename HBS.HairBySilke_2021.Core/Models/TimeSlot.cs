using System;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.Core.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public TimeRange TimeRange { get; set; }
        public bool IsAvailable { get; set; }
    }
}