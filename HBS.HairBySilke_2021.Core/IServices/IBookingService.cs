using System;
using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;
using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface IBookingService
    {
        Appointment BookAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
    }
}