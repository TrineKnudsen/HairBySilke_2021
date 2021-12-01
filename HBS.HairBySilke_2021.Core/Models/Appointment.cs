using System;

namespace HBS.HairBySilke_2021.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Treatment Treatment { get; set; }
        public string TreatmentName { get; set; }
        public int TreatmentId { get; set; }
        public Customer Customer { get; set; }
        //public int AdminId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public int TimeSlotId { get; set; }
        
        public DateTime Start { get; set; }
    }
}