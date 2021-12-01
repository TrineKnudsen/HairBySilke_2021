using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface ITimeSlotService
    {
        TimeSlot[] GetAvailableTimeSlots();

        TimeSlot[] GetAvailableTimeSlotsByTreatment(int duration);
    }
}