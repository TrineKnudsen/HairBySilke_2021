using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test.Models
{
    public class AppointmentTest
    {
        private readonly Appointment _appointment;
        public AppointmentTest()
        {
           _appointment = new Appointment(); 
        }
        [Fact]
        public void Appointment_CanBeInitialized()
        {
            Assert.NotNull(_appointment);
        }

        [Fact]
        public void Appointment_SetId_StoresId()
        {
            _appointment.Id = 1;
            Assert.Equal(1, _appointment.Id);
        }

        [Fact]
        public void Appointment_Id_MustBeInt()
        {
            Assert.True(_appointment.Id is int);
        }
    }
}