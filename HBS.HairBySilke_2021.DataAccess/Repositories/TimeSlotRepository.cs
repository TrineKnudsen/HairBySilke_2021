using System;
using System.Collections.Generic;
using System.Linq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly MainDbContext _ctx;

        public TimeSlotRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<TimeSlot> GetAvailableTimeSlots()
        {
            var timeslots = _ctx.TimeSlots
                .Select(ts => new TimeSlot
                {
                    Id = ts.Id,
                    IsAvailable = ts.IsAvailable,
                    Start = ts.Start,
                    Duration = ts.Duration
                }).ToList();

            return timeslots;
        }

        public List<TimeSlot> GetAvailableTimeSlotsByTreatment(double duration)
        {
            var timeslots = GetAvailableTimeSlots().Where(ts => Math.Abs(ts.Duration.TotalMinutes - duration) < 0.2)
                .ToList();

            return timeslots;
        }
    }
}