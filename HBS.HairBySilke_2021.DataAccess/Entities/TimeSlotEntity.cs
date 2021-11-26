using System;
using HBS.HairBySilke_2021.Core.Models;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class TimeSlotEntity
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        
        public bool IsAvailable { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentEntity Appointment { get; set; }
    }
}