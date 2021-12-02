using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class ITreatmentServiceTest
    {
        /*
         * Test to see if we have a interface for treatment service.
         */
        [Fact]
        public void ITreatmentService_IsAvailable()
        {
            var service = new Mock<ITreatmentsService>().Object;
            Assert.NotNull(service);
        }

        /*
         * Test to have a GetAll method with no parameters that returns a list of all treatments.
         * This is not testing the actual implementation, but just that we have the method available in the interface.
         */
        [Fact]
        public void GetTreatments_WithNoParams_ReturnsListOfAllTreatments()
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