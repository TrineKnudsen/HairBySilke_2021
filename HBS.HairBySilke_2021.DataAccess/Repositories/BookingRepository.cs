using System;
using System.Collections.Generic;
using System.IO;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MainDbContext _ctx;

        public BookingRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        public Appointment CreateAppointment(TimeSlot timeSlot, Treatment treatment, Admin admin, Customer customer)
        {
            throw new NotImplementedException();
        }

        public TimeSlot[] GetAvailableTimeSlots(DateTime maxDateTime)
        {
            DateTime minDateTime = DateTime.Now;

            List<DateTime> allDates = new List<DateTime>();
            List<TimeSlot> timeSlots = new List<TimeSlot>();

            for (DateTime date = minDateTime; date <= maxDateTime; date = date.AddDays(1))
                allDates.Add(date);
            foreach (var date in allDates)
            {
                if (date.DayOfWeek is DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday or DayOfWeek
                    .Friday)
                {
                    var timeSlot1 = new TimeSlot
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 9, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 10, 0, 0)
                        )
                    };
                    var timeSlot2 = new TimeSlot
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 10, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 12, 0, 0)
                        )
                    };
                    var timeSlot3 = new TimeSlot
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 12, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 14, 0, 0)
                        )
                    };
                    var timeSlot4 = new TimeSlot
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 14, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 15, 0, 0)
                        )
                    };
                    var timeSlot5 = new TimeSlot
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 15, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 16, 0, 0)
                        )
                    };
                    timeSlots.Add(timeSlot1);
                    timeSlots.Add(timeSlot2);
                    timeSlots.Add(timeSlot3);
                    timeSlots.Add(timeSlot4);
                    timeSlots.Add(timeSlot5);
                }

                if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    throw new InvalidDataException("We are closed on mondays");
                }

                foreach (var timeslot in timeSlots)
                {
                    TimeSlotEntity timeSlotEntity = new TimeSlotEntity
                    {
                        Id = timeslot.Id,
                        AppointmentId = timeslot.Appointment.Id,
                        IsAvailable = timeslot.IsAvailable,
                        TimeRange = timeslot.TimeRange
                    };
                    _ctx.TimeSlots.Add(timeSlotEntity);
                    _ctx.SaveChanges();
                }
            }
            return timeSlots.ToArray();
        }
    }
}