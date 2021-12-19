using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Domain.Test.IRepositories
{
    public class IBookingRepositoryTest
    {
        [Fact]
        public void IBookingRepository_IsAvailable()
        {
            var bookingRepository = new Mock<IBookingRepository>().Object;
            Assert.NotNull(bookingRepository);
        }
        
        [Fact]
        public void ReadAllApp_WithNoParams_ReturnsListOfAllBookings()
        {
            var mock = new Mock<IBookingRepository>();
            var fakeList = new List<Appointment>();
            mock.Setup(s => s.ReadAllApp())
                .Returns(fakeList);
            var bookingRepo = mock.Object;
            Assert.Equal(fakeList, bookingRepo.ReadAllApp());
        }
        
        
    }
}