using System.Collections.Generic;
using System.IO;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.Services
{
    public class TreatmentsService : ITreatmentsService
    {
        private readonly ITreatmentsRepository _treatmentsRepository;

        public TreatmentsService(ITreatmentsRepository treatmentsRepository)
        {
            _treatmentsRepository = treatmentsRepository ?? throw new InvalidDataException("TreatmentRepository cannot be null");
        }

        public List<Treatment> GetAllTreatments()
        {
            return _treatmentsRepository.ReadAllTreatments();
        }
    }
}