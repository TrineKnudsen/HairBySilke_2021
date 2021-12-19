using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Domain.Test
{
    public class ITimeSlotRepositoryTest
    {
        [Fact]
        public void ITimeSlotRepository_IsAvailable()
        {
            var repository = new Mock<ITimeSlotRepository>().Object;
            Assert.NotNull(repository);
        }

        [Fact]
        public void GetAvailableTimeSlots_NoParams_ReturnsAListOfTimeSlots()
        {
            var mock = new Mock<ITimeSlotRepository>();
            var fakeList = new List<TimeSlot>();
            mock.Setup(s => s.GetAvailableTimeSlots())
                .Returns(fakeList);
            var repo = mock.Object;
            Assert.Equal(fakeList, repo.GetAvailableTimeSlots());
        }

        [Fact]
        public void GetAvailableTimeSlotsByTreatment_ParamDuration_ReturnsAListOfTimeSlots()
        {
            var mock = new Mock<ITimeSlotRepository>();
            var fakeList = new List<TimeSlot>();
            mock.Setup(s => s.GetAvailableTimeSlotsByTreatment(100.2))
                .Returns(fakeList);
            var repo = mock.Object;
            Assert.Equal(fakeList, repo.GetAvailableTimeSlotsByTreatment(100.2));
        }
    }
}