using System;
using System.Collections.Generic;
using System.Linq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        
        private readonly MainDbContext _ctx;

        public TimeSlotRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public TimeSlot[] GetAvailableTimeSlots()
        {
            DateTime minDateTime = new DateTime(2021, 11, 26, 09, 0, 0);
            DateTime maxDateTime = new DateTime(2021, 12, 10, 16, 0, 0);

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
                        Start = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 10, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 10, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 9, 0, 0))
                    };
                    var timeSlot2 = new TimeSlot
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 10, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 12, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 10, 0, 0))
                    };
                    var timeSlot3 = new TimeSlot
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 14, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 12, 0, 0))
                    };
                    var timeSlot4 = new TimeSlot
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 15, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 14, 0, 0))
                    };
                    var timeSlot5 = new TimeSlot
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 16, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 15, 0, 0))
                    };
                    timeSlots.Add(timeSlot1);
                    timeSlots.Add(timeSlot2);
                    timeSlots.Add(timeSlot3);
                    timeSlots.Add(timeSlot4);
                    timeSlots.Add(timeSlot5);
                }

                var entites = timeSlots.Select(ts => new TimeSlotEntity
                {
                    Id = ts.Id,
                    IsAvailable = ts.IsAvailable,
                    Start = ts.Start,
                    Duration = ts.Duration
                });
                _ctx.AddRange(entites);
                _ctx.SaveChanges();
                /*foreach (var timeslot in timeSlots)
                {
                    TimeSlotEntity timeSlotEntity = new TimeSlotEntity
                    {
                        Id = timeslot.Id,
                        IsAvailable = timeslot.IsAvailable,
                        Start = timeslot.Start,
                        Duration = timeslot.Duration
                    };
                    _ctx.TimeSlots.Add(timeSlotEntity);
                    _ctx.SaveChanges();
                }*/
            }

            return timeSlots.ToArray();
        }

        public TimeSlot[] GetAvailableTimeSlotsByTreatment(int duration)
        {
            return GetAvailableTimeSlots()
                .Where(t => t.Duration.TotalMinutes == duration)
                .ToArray();
        }
    }
}