using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using HBS.HairBySilke_2021.DataAccess.Repositories;
using Xunit;

namespace HBS.HairBySilke_2021.DataAccess.Test
{
    public class TimeslotRepositoryTest
    {
        [Fact]
        public void TimeslotRepository_IsTimeslotRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new TimeSlotRepository(fakeContext);
            Assert.IsAssignableFrom<ITimeSlotRepository>(repository);
        }

        [Fact]
        public void TimeslotRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new TimeSlotRepository(null));
        }

        [Fact]
        public void TimeslotRepository_WithNullDbContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new TimeSlotRepository(null));
            Assert.Equal("TimeslotRepository skal have en DBContext", exception.Message);
        }

        [Fact]
        public void FindAll_GetAllTimeslotEntitiesInDbContext_ReturnsAsListOfTimeslots()
        {
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new TimeSlotRepository(fakeContext);
            var list = new List<TimeSlotEntity>
            {
                new TimeSlotEntity
                {
                    DayOfWeek = "Friday",
                    Start = new DateTime(2022, 12, 10, 10, 0, 0),
                    End = new DateTime(2022, 12, 10, 12, 0, 0),
                    Duration = new DateTime(2022, 12, 10, 12, 0, 0)
                               - new DateTime(2022, 12, 10, 10, 0, 0),
                    Id = 1, IsAvailable = true
                }
            };
            fakeContext.Set<TimeSlotEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(te => new TimeSlot
            {
                Id = te.Id,
                Start = te.Start,
                End = te.End,
                Duration = te.Duration,
                IsAvailable = true,
            }).ToList();

            //Act
            var actualResult = repository.GetAvailableTimeSlots();

            //Assert
            Assert.Equal(expectedList, actualResult, new Comparer());
        }

        [Fact]
        public void FindAllAvailableTimeSlots_WithParamDurationTooSmall_ThrowInvalidDataExceptionWithMessage()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new TimeSlotRepository(fakeContext);
            var exception = Assert
                .Throws<InvalidDataException>(() => repository.GetAvailableTimeSlotsByTreatment(20));
            Assert.Equal("Vælg en behandling du ønsker at bestille tid til.", exception.Message);
        }

        [Fact]
        public void FindAllAvailableTimeslots_ByTreatment_ReturnsAListOfAvailableTimeSlots()
        {
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new TimeSlotRepository(fakeContext);
            var treatmentEntity = new TreatmentEntity
            {
                Duration = 120, Price = 200, TreatmentName = "Dameklip"
            };
            fakeContext.Set<TreatmentEntity>().Add(treatmentEntity);
            fakeContext.SaveChanges();
            var timeslotEntity = new List<TimeSlotEntity>
            {
                new TimeSlotEntity
                {
                    DayOfWeek = "Friday",
                    Start = new DateTime(2022, 12, 10, 10, 0, 0),
                    End = new DateTime(2022, 12, 10, 12, 0, 0),
                    Duration = new DateTime(2022, 12, 10, 12, 0, 0)
                               - new DateTime(2022, 12, 10, 10, 0, 0),
                    IsAvailable = true
                },
                new TimeSlotEntity
                {
                    DayOfWeek = "Friday",
                    Start = new DateTime(2022, 12, 10, 12, 0, 0),
                    End = new DateTime(2022, 12, 10, 13, 0, 0),
                    Duration = new DateTime(2022, 12, 10, 13, 0, 0)
                               - new DateTime(2022, 12, 10, 12, 0, 0),
                    IsAvailable = false
                }
            };
            fakeContext.Set<TimeSlotEntity>().AddRange(timeslotEntity);
            fakeContext.SaveChanges();

            var expectedList = new List<TimeSlot>();
            expectedList.Add(new TimeSlot
            {
                Start = new DateTime(2022, 12, 10, 10, 0, 0),
                End = new DateTime(2022, 12, 10, 12, 0, 0),
                Duration = new DateTime(2022, 12, 10, 12, 0, 0) - new DateTime(2022, 12, 10, 10, 0, 0),
                Id = 1, IsAvailable = true
            });

            var actual = repository.GetAvailableTimeSlotsByTreatment(120);

            Assert.Equal(expectedList, actual, new Comparer());
        }
    }

    public partial class Comparer : IEqualityComparer<TimeSlot>
    {
        public bool Equals(TimeSlot x, TimeSlot y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Duration == y.Duration && x.End == y.End && x.Start == y.Start &&
                   x.IsAvailable == y.IsAvailable && x.AppointmentId == y.AppointmentId;
        }

        public int GetHashCode(TimeSlot obj)
        {
            return HashCode.Combine(obj.Id, obj.Duration, obj.Start, obj.End, obj.IsAvailable, obj.AppointmentId);
        }
    }
}