using System;
using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface IBookingRepository
    {
        Appointment CreateAppointment(Appointment appointment);
    }
}