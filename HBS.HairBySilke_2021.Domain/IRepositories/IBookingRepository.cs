using System;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface IBookingRepository
    {
        Appointment CreateAppointment(TimeSlot timeSlot, Treatment treatment, Admin admin, Customer customer);
        TimeSlot[] GetAvailableTimeSlots(DateTime maxDateTime);
    }
}