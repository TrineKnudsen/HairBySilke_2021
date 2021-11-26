using System;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface IBookingService
    {
        TimeSlot[] GetAvailableTimeSlots();
    }
}