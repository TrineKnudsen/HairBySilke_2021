using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface IAdminRepository
    { 
        Appointment CreateAppointment(Appointment appointment, Customer customer);

        List<Appointment> ReadAllAppointments();

        Appointment UpdateAppointment(Appointment appointmentToUpdate);

        void DeleteAppointment(int id);
    }
}