using System;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

           /* _ctx.Admins.Add(new AdminEntity
            {
                Name = "Silke"
            });

            _ctx.Customers.Add(new CustomerEntity
            {
                Email = "trine@hotmail.com",
                Name = "Trine Knudsen",
                PhoneNumber = "51889466"
            });

            _ctx.Treatments.Add(new TreatmentEntity
            {
                AppointmentId = 1,
                Price = 420,
                TreatmentName = "Klip"
            });

            _ctx.TimeSlots.Add(new TimeSlotEntity
            {
                AppointmentId = 1,
                IsAvailable = false,
                TimeRange = new TimeRange(new DateTime(2021, 11, 27, 9, 0, 0),
                new DateTime(2021, 11, 27, 10, 0, 0))
            });

            _ctx.Appointments.Add(new AppointmentEntity
            {
                AdminId = 1,
                CustomerId = 1,
                TreatmentId = 1,
                TimeSlot = new TimeSlotEntity
                {
                    IsAvailable = false,
                    TimeRange = new TimeRange(
                        new DateTime(2021, 11,27,9,0,0),
                        new DateTime(2021, 11,27,10,0,0))
                }
            });*/
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}