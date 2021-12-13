using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using HBS.HairBySilke_2021.DataAccess.Repositories;
using Itenso.TimePeriod;
using Xunit;

namespace HBS.HairBySilke_2021.DataAccess.Test
{
    public class BookingControllerTest
    {
        [Fact]
        public void BookingRepository_IsIBookingRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new BookingRepository(fakeContext);
            Assert.IsAssignableFrom<IBookingRepository>(repository);
        }

        [Fact]
        public void BookingRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new BookingRepository(null));
        }

        [Fact]
        public void BookingRepository_WithNullDbContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new BookingRepository(null));
            Assert.Equal("Booking repository must have a DbContext", exception.Message);
        }

        [Fact]
        public void CreateBookingEntity_WithNullTreatmentEntityTimeSlotEntityCustomerEntity_ThrowsNullReferenceException()
        {
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new BookingRepository(fakeContext);
            var appointment = new Appointment
            {
                Customer = new Customer
                {
                    Email = "trine@hotmail.com",
                    Id = 1,
                    Name = "Trine Knudsen",
                    PhoneNumber = "12345678"
                },
                Id = 1,
            };
            Assert.Throws<NullReferenceException>(() => repository.CreateAppointment(appointment));
        }

    }

    public partial class Comparer : IEqualityComparer<Appointment>
    {
        public bool Equals(Appointment x, Appointment y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.TreatmentName == y.TreatmentName && x.Start == y.Start && x.Id == y.Id &&
                   x.TreatmentId == y.TreatmentId && x.TimeSlotId == y.TimeSlotId;
        }

        public int GetHashCode(Appointment obj)
        {
            return HashCode.Combine(obj.Id, obj.TreatmentName, obj.Start, obj.TreatmentId, obj.TimeSlotId);
        }
    }
}