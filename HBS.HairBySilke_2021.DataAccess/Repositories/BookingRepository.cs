using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;

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
            var timeslot =
                _ctx.TimeSlots.FirstOrDefault(ts => ts.Start == appointment.Start);
            var treatment = _ctx.Treatments.FirstOrDefault(t => t.TreatmentName == appointment.TreatmentName);

            if (treatment == null || timeslot == null) return null;
            var ae = new AppointmentEntity
            {
                TimeSlotId = timeslot.Id,
                TimeSlot = timeslot,
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
            _ctx.Appointments.Add(ae);
            _ctx.SaveChanges();

            return new Appointment
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
    }
}