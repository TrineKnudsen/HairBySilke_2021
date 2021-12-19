using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class IBookingServiceTest
    {
        [Fact]
        public void IBookingService_IsAvailable()
        {
            var bookingService = new Mock<IBookingService>().Object;
            Assert.NotNull(bookingService);
        }

        [Fact]
        public void GetBookings_WithNoParams_ReturnsListOfAllBookings()
        {
            var mock = new Mock<IBookingService>();
            var fakeList = new List<Appointment>();
            mock.Setup(s => s.GetAllApp())
                .Returns(fakeList);
            var bookingService = mock.Object;
            Assert.Equal(fakeList, bookingService.GetAllApp());
        }
        
    }
}