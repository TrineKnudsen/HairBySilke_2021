using System;
using System.Collections.Generic;
using System.Linq;
using HBS.HairBySilke_2021.DataAccess.Entities;


namespace HBS.HairBySilke_2021.DataAccess
{
    public class DbSeeder: IMainDbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }


        public void SeedDevelopment()
        {
            _ctx.Database.EnsureCreated();

            var treatments = GetTreatments();
            _ctx.Treatments.AddRange(treatments);

            var timeSlots = GetAvailableTimeSlots();
            _ctx.TimeSlots.AddRange(timeSlots);
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();

            var treatments = GetTreatments();
            _ctx.Treatments.AddRange(treatments);

            var timeSlots = GetAvailableTimeSlots();
            _ctx.TimeSlots.AddRange(timeSlots);

            _ctx.SaveChanges();
        }

        private TimeSlotEntity[] GetAvailableTimeSlots()
        {
            var minDateTime = DateTime.Now;
            var maxDateTime = minDateTime.AddDays(90);

            var allDates = new List<DateTime>();
            var entities = new List<TimeSlotEntity>();

            for (var date = minDateTime; date <= maxDateTime; date = date.AddDays(1))
                allDates.Add(date);
            foreach (var date in allDates)
            {
                if (date.DayOfWeek is DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday or DayOfWeek
                    .Friday)
                {
                    var timeSlot1 = new TimeSlotEntity
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 10, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 10, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 9, 0, 0))
                    };
                    var timeSlot2 = new TimeSlotEntity
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 10, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 12, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 10, 0, 0))
                    };
                    var timeSlot3 = new TimeSlotEntity
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 14, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 12, 0, 0))
                    };
                    var timeSlot4 = new TimeSlotEntity
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 15, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 14, 0, 0))
                    };
                    var timeSlot5 = new TimeSlotEntity
                    {
                        IsAvailable = true,
                        Start = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0),
                        End = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0),
                        Duration = (new DateTime(date.Year, date.Month, date.Day, 16, 0, 0)) -
                                   (new DateTime(date.Year, date.Month, date.Day, 15, 0, 0))
                    };
                    entities.Add(timeSlot1);
                    entities.Add(timeSlot2);
                    entities.Add(timeSlot3);
                    entities.Add(timeSlot4);
                    entities.Add(timeSlot5);
                }
            }

            return entities.ToArray();
        }

        private TreatmentEntity[] GetTreatments()
        {
            var treatmentEntities = new List<TreatmentEntity>();

            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Dameklip", Price = 325, Duration = 45});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Bundfarve", Price = 415, Duration = 90});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Helfarve", Price = 500, Duration = 100});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Balayage", Price = 875, Duration = 120});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Balayage + Bundfarve", Price = 1075, Duration = 180});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Toning", Price = 250, Duration = 45});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Striber - kort hår", Price = 420, Duration = 120});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Striber - Skulderlangt hår", Price = 630, Duration = 150});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Striber - Langt hår", Price = 775, Duration = 150});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Permanent - kort hår", Price = 575, Duration = 150});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Permanent - Skulderlangt hår", Price = 755, Duration = 120});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Permanent - Langt hår", Price = 875, Duration = 150});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Bryn retning m. blad", Price = 20, Duration = 10});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Bryn retning m. pincet", Price = 50, Duration = 10});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Bryn farve", Price = 50, Duration = 20});
            treatmentEntities.Add(new TreatmentEntity
                {TreatmentName = "Bryn farve + retning", Price = 85, Duration = 30});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Vipper farvning", Price = 85, Duration = 15});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Bryn + vipper", Price = 150, Duration = 30});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Kurbehandling", Price = 150, Duration = 15});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Hverdagsmakeup", Price = 300, Duration = 30});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Festmakeup", Price = 450, Duration = 30});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Bryllupsmakeup", Price = 550, Duration = 45});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Herreklip", Price = 245, Duration = 30});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Skægklip", Price = 150, Duration = 30});
            treatmentEntities.Add(new TreatmentEntity {TreatmentName = "Glatbarbering", Price = 150, Duration = 30});

            return treatmentEntities.ToArray();
        }
    }
}