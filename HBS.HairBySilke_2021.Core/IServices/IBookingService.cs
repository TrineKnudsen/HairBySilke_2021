using System;
using HBS.HairBySilke_2021.Core.Models;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface IBookingService
    {
        TimeSlot[] GetAvailableTimeSlots();

        TimeSlot[] GetAvailableTimeSlotsByTreatment(int duration);
        Appointment BookAppointment(Appointment appointment);
    }
}