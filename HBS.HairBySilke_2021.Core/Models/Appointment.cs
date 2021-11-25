using System;
using System.Collections.Generic;

namespace HBS.HairBySilke_2021.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Treatment Treatment { get; set; }
        public int CustomerId { get; set; }
        public int AdminId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}