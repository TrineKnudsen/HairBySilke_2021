using HBS.HairBySilke_2021.Core.Models;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class TimeSlotEntity
    {
        public int Id { get; set; }
        public TimeRange TimeRange { get; set; }
        public bool IsAvailable { get; set; }
        
        public int AppointmentId { get; set; }
        public AppointmentEntity Appointment { get; set; }
    }
}