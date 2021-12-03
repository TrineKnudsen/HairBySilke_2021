using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public Appointment CreateAppointment(Appointment appointment, Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Appointment> ReadAllAppointments()
        {
            throw new System.NotImplementedException();
        }

        public Appointment UpdateAppointment(Appointment appointmentToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAppointment(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}