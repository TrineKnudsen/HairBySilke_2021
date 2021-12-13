using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MainDbContext _ctx;

        public BookingRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("Booking repository must have a DbContext");
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            var timeslot = _ctx.TimeSlots
                .FirstOrDefault(ts => ts.Start == appointment.Start);
            var treatment = _ctx.Treatments
                .FirstOrDefault(t => t.TreatmentName == appointment.TreatmentName);

            if (timeslot == null || treatment == null)
            {
                throw new NullReferenceException("Noget gik galt. Start forfra...");
            }
            var ae = new AppointmentEntity
            {
                TimeSlotId = timeslot.Id,
                TimeSlot = new TimeSlotEntity
                {
                    Id = timeslot.Id,
                    DayOfWeek = timeslot.DayOfWeek,
                    Duration = timeslot.Duration,
                    End = timeslot.End,
                    Start = timeslot.Start,
                    IsAvailable = false
                },
                Treatment = treatment,
                TreatmentId = treatment.Id,
                Customer = new CustomerEntity
                {
                    Email = appointment.Customer.Email,
                    PhoneNumber = appointment.Customer.PhoneNumber,
                    Name = appointment.Customer.Name
                },
                CustomerId = appointment.Customer.Id,
            };
            _ctx.TimeSlots.Remove(timeslot);
            _ctx.SaveChanges();
            _ctx.Appointments.Add(ae);
            _ctx.SaveChanges();

            var app = new Appointment
            {
                Id = ae.Id,
                TimeSlotId = ae.TimeSlotId,
                TreatmentId = ae.TreatmentId,
                TreatmentName = ae.Treatment.TreatmentName,
                Start = ae.TimeSlot.Start,
                Customer = new Customer
                {
                    Email = ae.Customer.Email,
                    Name = ae.Customer.Name,
                    PhoneNumber = ae.Customer.PhoneNumber,
                    Id = ae.CustomerId
                }
            };
            return app;
        }

        public List<Appointment> ReadAllApp()
        {
            return _ctx.Appointments
                .Select(pe => new Appointment
                {
                    Id = pe.Id,
                    Customer = new Customer
                    {
                        Email = pe.Customer.Email,
                        Name = pe.Customer.Name,
                        PhoneNumber = pe.Customer.PhoneNumber,
                        Id = pe.Id
                    },
                    Start = pe.TimeSlot.Start,
                    TimeSlotId = pe.TimeSlotId,
                    TreatmentId = pe.TreatmentId,
                    TreatmentName = pe.Treatment.TreatmentName
                }).ToList();
        }

        public List<Appointment> GetDailyApp(string dayOfWeek)
        {
            var dow = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), dayOfWeek);
            var entityList = _ctx.Appointments
                .Include(a => a.Treatment)
                .Include(a => a.TimeSlot)
                .Where(a => a.TimeSlot.Start.DayOfWeek == dow);


            var appList = new List<Appointment>();

            foreach (var appEntity in entityList)
            {
                appList.Add(new Appointment
                {
                    Start = appEntity.TimeSlot.Start,
                    TreatmentName = appEntity.Treatment.TreatmentName
                });
            }

            return appList;
        }

        public Appointment UpdateAppointment(int appointmentIdToUpdate, Appointment updatedAppointment)
        {
            try
            {
                var appointmentToUpdateEntity = _ctx.Appointments
                    .Include(ae => ae.Customer)
                    .FirstOrDefault(ae => ae.Id == appointmentIdToUpdate);
                var timeslotEntity = _ctx.TimeSlots
                    .FirstOrDefault(tse => tse.Start == updatedAppointment.Start);
                var treatmentEntity = _ctx.Treatments
                    .FirstOrDefault(te => te.TreatmentName == updatedAppointment.TreatmentName);

                if (appointmentToUpdateEntity != null && timeslotEntity != null && treatmentEntity != null)
                {
                    var updatedAppointmentEntity = new AppointmentEntity
                    {
                        Customer = appointmentToUpdateEntity.Customer,
                        CustomerId = appointmentToUpdateEntity.CustomerId,
                        Id = appointmentToUpdateEntity.Id,
                        TimeSlot = timeslotEntity,
                        TimeSlotId = timeslotEntity.Id,
                        Treatment = treatmentEntity,
                        TreatmentId = treatmentEntity.Id
                    };
                    _ctx.Appointments.Remove(appointmentToUpdateEntity);
                    _ctx.Appointments.Add(updatedAppointmentEntity);
                    _ctx.SaveChanges();

                    return new Appointment
                    {
                        Customer = updatedAppointment.Customer,
                        Id = updatedAppointment.Id,
                        TimeSlotId = timeslotEntity.Id,
                        TreatmentId = treatmentEntity.Id,
                        TreatmentName = updatedAppointmentEntity.Treatment.TreatmentName,
                        Start = updatedAppointmentEntity.TimeSlot.Start
                    };
                }
            }

            catch (InvalidDataException e)
            {
                throw new InvalidDataException();
            }

            return null;
        }

        public void DeleteAppointment(int id)
        {
            var appointmentEntity = _ctx.Appointments
                .Include(a => a.TimeSlot)
                .FirstOrDefault(a => a.Id == id);

            if (appointmentEntity != null)
            {
                var timeslot = new TimeSlotEntity
                {
                    Id = appointmentEntity.TimeSlot.Id,
                    DayOfWeek = appointmentEntity.TimeSlot.DayOfWeek,
                    Duration = appointmentEntity.TimeSlot.Duration,
                    End = appointmentEntity.TimeSlot.End,
                    IsAvailable = true,
                    Start = appointmentEntity.TimeSlot.Start
                };

                _ctx.Appointments.Remove(appointmentEntity);
                _ctx.TimeSlots.Remove(appointmentEntity.TimeSlot);
                _ctx.SaveChanges();
                _ctx.TimeSlots.Add(timeslot);
            }

            _ctx.SaveChanges();
        }

        public Appointment GetAppointment(int id)
        {
            var appointmentEntity = _ctx.Appointments
                .Include(a => a.TimeSlot)
                .Include(a => a.Customer)
                .Include(a => a.Treatment)
                .FirstOrDefault(a => a.Id == id);

            var appointment = new Appointment
            {
                Id = appointmentEntity.Id,
                Start = appointmentEntity.TimeSlot.Start,
                TimeSlotId = appointmentEntity.TimeSlot.Id,
                TreatmentId = appointmentEntity.Treatment.Id,
                TreatmentName = appointmentEntity.Treatment.TreatmentName,
                Customer = new Customer
                {
                    Email = appointmentEntity.Customer.Email,
                    Id = appointmentEntity.Customer.Id,
                    Name = appointmentEntity.Customer.Name,
                    PhoneNumber = appointmentEntity.Customer.PhoneNumber
                }
            };
            return appointment;
        }
    }
}