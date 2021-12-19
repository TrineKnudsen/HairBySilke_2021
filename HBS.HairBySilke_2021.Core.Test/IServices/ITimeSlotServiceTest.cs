using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class ITimeSlotServiceTest
    {
        [Fact]
        public void ITimeSlotService_IsAvailable()
        {
            var service = new Mock<ITimeSlotService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetAvailableTimeSlots_NoParams_ReturnsAListOfTimeSlots()
        {
            var mock = new Mock<ITimeSlotService>();
            var fakeList = new List<TimeSlot>();
            mock.Setup(s => s.GetAvailableTimeSlots())
                .Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetAvailableTimeSlots());
        }

        [Fact]
        public void GetAvailableTimeSlotsByTreatment_ParamDuration_ReturnsAListOfTimeSlots()
        {
            var mock = new Mock<ITimeSlotService>();
            var fakeList = new List<TimeSlot>();
            mock.Setup(s => s.GetAvailableTimeSlotsByTreatment(100.2))
                .Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetAvailableTimeSlotsByTreatment(100.2));
        }
    }
}