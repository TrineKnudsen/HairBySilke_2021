using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface ITreatmentsRepository
    {
        List<Treatment> ReadAllTreatments();
        
        
    }
}