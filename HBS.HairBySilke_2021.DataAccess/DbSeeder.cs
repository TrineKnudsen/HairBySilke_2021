using System;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using Itenso.TimePeriod;
using HBS.HairBySilke_2021.DataAccess.Entities;
using HBS.HairBySilke_2021.DataAccess.Repositories;

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
            
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Dameklip", Price = 325, Duration = 150});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bundfarve", Price = 415, Duration = 120});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Helfarve", Price = 500, Duration = 150});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Balayage", Price = 875, Duration = 50});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Balayage + Bundfarve", Price = 1075});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Toning", Price = 250});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Striber - kort hår", Price = 420});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Striber - Skulderlangt hår", Price = 630});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Striber - Langt hår", Price = 775});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Tillæg: tykt hår", Price = 100});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Permanent - kort hår", Price = 575});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Permanent - Skulderlangt hår", Price = 755});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Permanent - Langt hår", Price = 875});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Tillæg: klipning", Price = 100});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bryn retning m. blad", Price = 20});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bryn retning m. pincet", Price = 50});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bryn farve", Price = 50});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bryn farve + retning", Price = 85});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Vipper farvning", Price = 85});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bryn + vipper", Price = 150});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Kurbehandling", Price = 150});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Hverdagsmakeup", Price = 300});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Festmakeup", Price = 450});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Bryllupsmakeup", Price = 550});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Herreklip", Price = 245});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Skægklip", Price = 150});
            _ctx.Treatments.Add(new TreatmentEntity {TreatmentName = "Glatbarbering", Price = 150});
            _ctx.SaveChanges();
        }


    }
}