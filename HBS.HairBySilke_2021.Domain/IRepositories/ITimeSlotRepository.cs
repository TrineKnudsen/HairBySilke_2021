using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface ITimeSlotRepository
    {
        TimeSlot[] GetAvailableTimeSlots();

        TimeSlot[] GetAvailableTimeSlotsByTreatment(int duration);
    }
}