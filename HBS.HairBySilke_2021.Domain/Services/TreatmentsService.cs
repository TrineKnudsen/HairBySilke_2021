using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.Services
{
    public class TreatmentsService : ITreatmentsService
    {
        private readonly ITreatmentsRepository _treatmentsRepository;

        public TreatmentsService(ITreatmentsRepository _treatmentsRepository)
        {
            this._treatmentsRepository = _treatmentsRepository;
        }

        public List<Treatment> GetAllTreatments()
        {
            return _treatmentsRepository.ReadAllTreatments();
        }
    }
}