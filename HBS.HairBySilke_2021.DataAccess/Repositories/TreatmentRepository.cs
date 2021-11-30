using System.Collections.Generic;
using System.Linq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class TreatmentRepository : ITreatmentsRepository
    {
        private readonly MainDbContext _ctx;

        public TreatmentRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Treatment> ReadAllTreatments()
        {
            return _ctx.Treatments
                .Select(te => new Treatment
                {
                    Id = te.Id,
                    Price = te.Price,
                    TreatmentName = te.TreatmentName,
                    Duration = te.Duration
                })
                .ToList();
        }

        public Treatment UpdateTreatment(Treatment treatmentToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}