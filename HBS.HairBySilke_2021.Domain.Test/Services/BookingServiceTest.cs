using System;
using System.Collections.Generic;
using System.IO;
using HBS.Domain.IRepositories;
using HBS.Domain.Services;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Domain.Test.Services
{
    public class BookingServiceTest
    {
        private readonly Mock<IBookingRepository> _mock;
        private readonly BookingService _service;
        private readonly List<Appointment> _expected;

        public BookingServiceTest()
        {
            _mock = new Mock<IBookingRepository>();
            _service = new BookingService(_mock.Object);
            _expected = new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    Start = new DateTime(2022, 1, 21, 10, 00, 00),
                    TreatmentName = "Balayage",
                    TreatmentId = 1,
                    TimeSlotId = 1,
                    Customer = new Customer
                        {Email = "lonehansen@hotmail.com", Name = "Lone Hansen", PhoneNumber = "12345678"},
                }
            };
        }

        [Fact]
        public void BookingService_IsIBookingService()
        {
            Assert.True(_service is IBookingService);
        }

        [Fact]
        public void BookingService_WithNullBookingRepository_ThrowsExceptionWthMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new BookingService(null)
            );
            Assert.Equal("Repository cannot be null", exception.Message);
        }

        [Fact]
        public void GetBooking_CallsBookingRepositoriesFindAll_ExactlyOnce()
        {
            _service.GetAllApp();
            _mock.Verify(r => r.ReadAllApp(), Times.Once);
        }

        [Fact]
        public void GetBookings_NoFilter_ReturnsListOfAllBookings()
        {
            _mock.Setup(r => r.ReadAllApp())
                .Returns(_expected);

            var actual = _service.GetAllApp();
            Assert.Equal(_expected, actual);
        }
        
        [Fact]
        public void BookAppointment_CallsBookingRepositoriesCreateAppointment_ExactlyOnce()
        {
            var appointment = new Appointment
            {
                Id = 1,
                Start = new DateTime(2022, 1, 21, 10, 00, 00),
                TreatmentName = "Balayage",
                TreatmentId = 1,
                TimeSlotId = 1,
                Customer = new Customer
                    {Email = "lonehansen@hotmail.com", Name = "Lone Hansen", PhoneNumber = "12345678"}
            };
            _service.BookAppointment(appointment);
            _mock.Verify(r => r.CreateAppointment(appointment));
        }

        [Fact]
        public void UpdateBooking_CallsBookingRepositoriesUpdateAppointment_ExactlyOnce()
        {
            var UpdatedApp = new Appointment
            {
                Id = 1,
                Start = new DateTime(2022, 1, 21, 10, 00, 00),
                TreatmentName = "Balayage",
                TreatmentId = 1,
                TimeSlotId = 1,
                Customer = new Customer
                    {Email = "lonehansen@hotmail.com", Name = "Lone Hansen", PhoneNumber = "12345678"}
            };
            _service.UpdateAppointment(1, UpdatedApp);
            _mock.Verify(r => r.UpdateAppointment(1, UpdatedApp), Times.Once);
        }

        [Fact]
        public void DeleteBooking_CallsBookingRepositoriesDeleteAppointment_ExactlyOnce()
        {
            _service.DeleteAppointment(1);
            _mock.Verify(r => r.DeleteAppointment(1));
        }
    }
}