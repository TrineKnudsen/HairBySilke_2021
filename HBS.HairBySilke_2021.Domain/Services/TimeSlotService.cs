using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private ITimeSlotRepository _repo;

        public TimeSlotService(ITimeSlotRepository repo)
        {
            _repo = repo;
        }
        
        public List<TimeSlot> GetAvailableTimeSlots()
        {
            return _repo.GetAvailableTimeSlots();
        }

        public List<TimeSlot> GetAvailableTimeSlotsByTreatment(double duration)
        {
            return _repo.GetAvailableTimeSlotsByTreatment(duration);
        }
    }
}