using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EntityFrameworkCore.Testing.Moq;
using EntityFrameworkCore.Testing.Moq.Helpers;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using HBS.HairBySilke_2021.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.DataAccess.Test
{
    public class BookingRepositoryTest
    {
        private readonly MainDbContext _fakeCtx;
        private readonly BookingRepository _repository;

        public BookingRepositoryTest()
        {
            _fakeCtx = Create.MockedDbContextFor<MainDbContext>();
            _repository = new BookingRepository(_fakeCtx);
            var appointmentEntity1 = new AppointmentEntity {
                Treatment = new TreatmentEntity {Duration = 120, Price = 200, TreatmentName = "Balayage"},
                Customer = new CustomerEntity {Email = "lonehansen@hotmail.com", Name = "Lone Hansen", PhoneNumber = "12345678"},
                TimeSlot = new TimeSlotEntity {
                    DayOfWeek = "Friday", 
                    Start = new DateTime(2022, 1, 21, 10, 00, 00),
                    End = new DateTime(2022, 1, 21, 12, 00, 00),
                    Duration = new DateTime(2022, 1, 21, 12, 00, 00) - new DateTime(2022, 1, 21, 10, 00, 00),
                    IsAvailable = false}, CustomerId = 1, TimeSlotId = 1, TreatmentId = 1};
            var appointmentEntity2 = new AppointmentEntity {
                Treatment = new TreatmentEntity {Duration = 60, Price = 400, TreatmentName = "Farve"},
                Customer = new CustomerEntity {Email = "erikhansen@hotmail.com", Name = "Erik Hansen", PhoneNumber = "12876678"},
                TimeSlot = new TimeSlotEntity {
                    DayOfWeek = "Monday",
                    Start = new DateTime(2022, 1, 21, 10, 00, 00),
                    End = new DateTime(2022, 1, 21, 11, 00, 00),
                    Duration = new DateTime(2022, 1, 21, 11, 00, 00) - new DateTime(2022, 1, 21, 10, 00, 00),
                    IsAvailable = false}, CustomerId = 2, TimeSlotId = 2, TreatmentId = 2};

            var timeSlot3 = new TimeSlotEntity
            {
                DayOfWeek = "Torsdag",
                Start = new DateTime(2022, 1, 20, 10, 00, 00),
                End = new DateTime(2022, 1, 20, 12, 00, 00),
                Duration = new DateTime(2022, 1, 20, 12, 00, 00) - new DateTime(2022, 1, 20, 10, 00, 00),
                IsAvailable = true
            };
            var treatment3 = new TreatmentEntity {Duration = 120, Price = 200, TreatmentName = "Dameklip"};
            _fakeCtx.Set<TreatmentEntity>().Add(treatment3);
            _fakeCtx.SaveChanges();
            _fakeCtx.Set<TimeSlotEntity>().AddRange(timeSlot3);
            _fakeCtx.SaveChanges();
            _fakeCtx.Set<AppointmentEntity>().AddRange(appointmentEntity1, appointmentEntity2);
            _fakeCtx.SaveChanges();
        }
        
        [Fact]
        public void BookingRepository_IsIBookingRepository()
        {
            Assert.IsAssignableFrom<IBookingRepository>(_repository);
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
        public void FindAll_GetAllAppointmentEntitiesInDbContext_AsListOfAppointment()
        {
            //Arrange
            var expectedList = _fakeCtx.Appointments.Select(te => new Appointment
            {
                Id = te.Id,
                TreatmentName = te.Treatment.TreatmentName,
                Customer = new Customer
                {
                    Email = te.Customer.Email,
                    Id = te.Customer.Id,
                    Name = te.Customer.Name,
                    PhoneNumber = te.Customer.PhoneNumber
                },
                TimeSlotId = te.TimeSlot.Id,
                TreatmentId = te.Treatment.Id,
                Start = te.TimeSlot.Start
            }).ToList();
            
            //Act
            var actualResult = _repository.ReadAllApp();
            
            //Assert
            Assert.Equal(expectedList, actualResult, new Comparer());
        }

        [Fact]
        public void CreateBooking_WithParam_ReturnsNewBooking()
        {
            //Arrange
            var newAppointment = new Appointment
            {
                Customer = new Customer
                {
                    Email = "trine@hotmail.com",
                    Name = "Trine Knudsen",
                    PhoneNumber = "12345678"
                }, Start = new DateTime(2022, 1, 20, 10, 00, 00),
                TreatmentName = "Dameklip"
            };
            var expectedApp = new Appointment
            {
                Id = 3,
                Customer = new Customer{Id = 3, Email = "trine@hotmail.com", Name = "Trine Knudsen", PhoneNumber = "12345678"},
                Start = newAppointment.Start,
                TimeSlotId = 1,
                TreatmentId = 1,
                TreatmentName = newAppointment.TreatmentName
            };
            var actualApp = _repository.CreateAppointment(newAppointment);
            Assert.Equal(expectedApp, actualApp, new Comparer());
        }

        [Fact]
        public void CreateBookingEntity_WithNullTreatmentEntityTimeSlotEntity_ThrowsNullReferenceExceptionWithMessage()
        {
            //Arrange
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
            var exception = Assert
                .Throws<NullReferenceException>(() => _repository.CreateAppointment(appointment));
            Assert.Equal("Noget gik galt. Vælg behandling og tidspunkt igen...", exception.Message);
        }
        
        [Fact]
        public void CreateBookingEntity_WithNullCustomer_ThrowsInvalidDataExceptionWithMessage()
        {
            //Arrange
            var treatmentEntity = new TreatmentEntity
            {
                TreatmentName = "Balayage",
                Price = 600
            };
            _fakeCtx.Set<TreatmentEntity>().Add(treatmentEntity);
            _fakeCtx.SaveChanges();
            var timeslotEntity = new TimeSlotEntity
            {
                Start = new DateTime(2022, 1, 28, 10, 00, 00),
                End = new DateTime(2022, 1, 28, 12, 00, 00),
                DayOfWeek = "Friday",
                Duration = new DateTime(2022, 1, 28, 12, 00, 00) - new DateTime(2022, 1, 28, 10, 00, 00),
                IsAvailable = true
            };
            _fakeCtx.Set<TimeSlotEntity>().Add(timeslotEntity);
            _fakeCtx.SaveChanges();
            var appointment = new Appointment
            {
                Customer = new Customer
                {
                    Email = "",
                    Id = 1,
                    Name = "j",
                    PhoneNumber = "345"
                },
                Id = 1,
                Start = new DateTime(2022, 1, 28, 10, 00, 00),
                TreatmentName = "Balayage",
            };
            var exception = Assert
                .Throws<InvalidDataException>(() => _repository.CreateAppointment(appointment));
            Assert.Equal("Noget gik galt. Skriv kontaktoplysninger igen...", exception.Message);
        }
        
        [Fact]
        public void UpdateAppointment_WithNullAppointmentToUpdateId_ReturnsNullReferenceExceptionWithMessage(){
            //Arrange
            var newAppointment = new Appointment
            {
                Customer = new Customer
                {
                    Email = "trine@hotmail.com",
                    Id = 1,
                    Name = "Trine Knudsen",
                    PhoneNumber = "12345678"
                },
                Start = new DateTime(2022,2, 25,10,00,00),
                TreatmentName = "Balayage"
            };
            var exception = Assert
                .Throws<NullReferenceException>(() => _repository.UpdateAppointment(0, newAppointment));
            Assert.Equal("Noget gik galt. Vælg en booking at opdatere igen...", exception.Message);
        }
        
        [Fact]
        public void UpdateAppointment_ParamAppointment_WithNullTreatmentOrTimeslot_ReturnsNullReferenceExceptionWithMessage(){
            //Arrange
            _fakeCtx.Set<AppointmentEntity>().Add(new AppointmentEntity
            {
                Customer = new CustomerEntity {Email = "trine@hotmail.com", Name = "Trine Knudsen", PhoneNumber = "12345678",}, CustomerId = 1,
                TimeSlot = new TimeSlotEntity
                {
                    Start = new DateTime(2022, 1, 28, 10, 00, 00), End = new DateTime(2022, 1, 28, 12, 00, 00),
                    DayOfWeek = "Friday",
                    Duration = new DateTime(2022, 1, 28, 12, 00, 00) - new DateTime(2022, 1, 28, 10, 00, 00),
                    IsAvailable = false
                }, TimeSlotId = 1,
                Treatment = new TreatmentEntity {Duration = 120, Price = 300, TreatmentName = "Balayage"}, TreatmentId = 1
            });
            _fakeCtx.SaveChanges();
            var updatedAppointment = new Appointment
            {
                Customer = new Customer
                {
                    Email = "trine@hotmail.com",
                    Id = 1,
                    Name = "Trine Knudsen",
                    PhoneNumber = "12345678"
                },
            };
            var exception = Assert
                .Throws<NullReferenceException>(() => _repository.UpdateAppointment(1, updatedAppointment));
            Assert.Equal("Noget gik galt. Vælg ny behandling og tidspunkt igen...", exception.Message);
        }

        [Fact]
        public void UpdateAppointment_WithParam_ReturnsUpdatedAppointment()
        {
            //Arrange
            var updatedAppointment = new Appointment
            {
                Start = new DateTime(2022, 1, 20, 10, 00, 00), TreatmentName = "Dameklip"
            };
            var expectedAppointment = new Appointment
            {
                Start = new DateTime(2022, 1, 20, 10, 00, 00),
                Customer = new Customer{Id = 1, Email = "lonehansen@hotmail.com", Name = "Lone Hansen", PhoneNumber = "12345678"},
                Id = 1, TimeSlotId = 1, TreatmentName = "Dameklip", TreatmentId = 1
            };
            var actual = _repository.UpdateAppointment(1, updatedAppointment);
            Assert.Equal(expectedAppointment, actual, new Comparer());
        }

        [Fact]
        public void DeleteAppointment_WithParamNullId_ThrowsNullReferenceException()
        {
            var exception = Assert
                .Throws<NullReferenceException>(() => _repository.DeleteAppointment(0));
            Assert.Equal("Noget gik galt. Vælg den aftale der skal aflyses", exception.Message);
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
            return x.Id == y.Id && x.TreatmentName == y.TreatmentName && x.Start == y.Start && 
                   x.TreatmentId == y.TreatmentId && x.TimeSlotId == y.TimeSlotId
                   && x.Customer.Email == y.Customer.Email && x.Customer.Id == y.Customer.Id && x.Customer.Name == y.Customer.Name && x.Customer.PhoneNumber == y.Customer.PhoneNumber;
        }

        public int GetHashCode(Appointment obj)
        {
            return HashCode.Combine(obj.Id, obj.TreatmentName, obj.Start, obj.TreatmentId, obj.TimeSlotId, obj.Customer);
        }
    }
}