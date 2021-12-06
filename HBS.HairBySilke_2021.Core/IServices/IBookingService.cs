using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;


namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface IBookingService
    {
        Appointment BookAppointment(Appointment appointment);

        List<Appointment> GetAllApp();

        List<Appointment> GetDailyApp(string dayOfWeek);
    }
}