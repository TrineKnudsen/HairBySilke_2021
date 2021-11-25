using System;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface IBookingRepository
    {
        TimeSlot[] GetAvailableTimeSlots(DateTime maxDateTime);
    }
}