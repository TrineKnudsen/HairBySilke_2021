using System;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }
        
        public TimeSlot[] GetAvailableTimeSlots()
        {
            return _repo.GetAvailableTimeSlots();
        }

        public TimeSlot[] GetAvailableTimeSlotsByTreatment(int duration)
        {
            return _repo.GetAvailableTimeSlotsByTreatment(duration);
        }
    }
}