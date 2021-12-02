using System.Collections.Generic;
using System.Linq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MainDbContext _ctx;

        public BookingRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            TimeSlotEntity timeslot = _ctx.TimeSlots.FirstOrDefault(ts => ts.Start == appointment.Start);
            TreatmentEntity treatment = _ctx.Treatments.FirstOrDefault(t => t.TreatmentName == appointment.TreatmentName);

            if (treatment != null && timeslot != null)
            {
                var ae = new AppointmentEntity
                {
                    TimeSlot = timeslot,
                    Treatment = treatment,
                    TimeSlotId = timeslot.Id,
                    TreatmentId = treatment.Id,
                    Customer = new CustomerEntity
                    {
                        Email = appointment.Customer.Email,
                        PhoneNumber = appointment.Customer.PhoneNumber,
                        Name = appointment.Customer.Name
                    }
                };
                _ctx.Appointments.Add(ae);
                _ctx.SaveChanges();
                
                return new Appointment
                {
                    Id = ae.Id,
                    TimeSlotId = ae.TimeSlotId,
                    TreatmentId = ae.TreatmentId,
                    TreatmentName = ae.Treatment.TreatmentName,
                    Start = ae.TimeSlot.Start
                };
            }
            return null;
        }
        
        public List<Appointment> ReadAllApp()
        {
            return _ctx.Appointments
                .Select(te => new Appointment()
                {
                    TreatmentName = te.Treatment.TreatmentName,
                    Start = te.TimeSlot.Start,
                    Customer = new Customer
                    {
                        Name = te.Customer.Name,
                        PhoneNumber = te.Customer.PhoneNumber,
                        Email = te.Customer.Email
                    }
                })
                .ToList();
        }
    }
}