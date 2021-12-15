using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;

namespace HBS.HairBySilke_2021.DataAccess.Converters
{
    public class AppointmentConverter
    {
        public Appointment Convert(AppointmentEntity entity)
        {
            return new Appointment
            {
                Id = entity.Id,
                Start = entity.TimeSlot.Start,
                TimeSlotId = entity.TimeSlotId,
                TreatmentName = entity.Treatment.TreatmentName,
                TreatmentId = entity.TreatmentId,
                Customer = new Customer
                {
                    Email = entity.Customer.Email,
                    Id = entity.Customer.Id,
                    Name = entity.Customer.Name,
                    PhoneNumber = entity.Customer.PhoneNumber
                }
            };
        }
    }
}