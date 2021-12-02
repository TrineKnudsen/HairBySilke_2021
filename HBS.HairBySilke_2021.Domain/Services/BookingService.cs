using System;
using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public Appointment BookAppointment(Appointment appointment)
        {
            return _repo.CreateAppointment(appointment);
        }


        public List<Appointment> GetAllAppointments()
        {
            return _repo.ReadAllApp();
        }


        public List<Appointment> GetDailyAppointments(string dayOfWeek)
        {
            return _repo.GetDailyAppointments(dayOfWeek);

        }
    }
}