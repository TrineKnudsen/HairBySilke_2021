using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class ITreatmentServiceTest
    {
        [Fact]
        public void ITreatmentService_IsAvailable()
        {
            var service = new Mock<ITreatmentsService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetAllTreatments_NoParams_ReturnsAListOfAllTreatment()
        {
            var mock = new Mock<ITreatmentsService>();
            var fakeList = new List<Treatment>();
            mock.Setup(s => s.GetAllTreatments())
                .Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetAllTreatments());
        }
    }
}