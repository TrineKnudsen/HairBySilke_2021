using System;
using System.Collections.Generic;
using System.IO;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
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
                    var timeSlot1 = new TimeSlot()
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 16, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 16, 0, 0)
                        )
                    };
                    timeSlots.Add(timeSlot1);
                }

                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    var timeSlot2 = new TimeSlot
                    {
                        IsAvailable = true,
                        TimeRange = new TimeRange(
                            new DateTime(date.Year, date.Minute, date.Second, 9, 0, 0),
                            new DateTime(date.Year, date.Minute, date.Second, 14, 0, 0)
                        )
                    };
                    timeSlots.Add(timeSlot2);
                }

                if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    throw new InvalidDataException("Monday we are closed");
                }
            }
            return timeSlots.ToArray();
        }
    }
}