using System;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface IBookingRepository
    {
        Appointment CreateAppointment(Appointment appointment);
        TimeSlot[] GetAvailableTimeSlots();

        TimeSlot[] GetAvailableTimeSlotsByTreatment(int duration);
    }
}