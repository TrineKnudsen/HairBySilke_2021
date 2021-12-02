using System.Collections.Generic;
using System.IO;
using HBS.Domain.IRepositories;
using HBS.Domain.Services;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using NuGet.Frameworks;
using Xunit;

namespace HBS.HairBySilke_2021.Domain.Test
{
    public class TreatmentServiceTest
    {
        private readonly Mock<ITreatmentsRepository> _mock;
        private readonly TreatmentsService _service;

        public TreatmentServiceTest()
        {
            _mock = new Mock<ITreatmentsRepository>();
            _service = new TreatmentsService(_mock.Object);


        }
        
        /*
         * Test to make sure that TreatmentService is the implementation class of
         * the interface ITreatmentService.
         * This test is also to make sure that the service has a data source.
         */
        [Fact]
        public void TreatmentService_IsITreatmentService()
        {
            Assert.True(_service is ITreatmentsService);
        }

        [Fact]
        public void TreatmentService_WithNullTreatmentRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new TreatmentsService(null));
            
        }
        
        [Fact]
        public void TreatmentService_WithNullTreatmentRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new TreatmentsService(null));
            Assert.Equal("TreatmentRepository can't be null", exception.Message);
        }

        /*
         * Test to make sure that the service only calls the RealAll method once.
         */
        [Fact]
        public void ReadAllCustomers_CallsTreatmentRepositoryReadAllTreatments_ExactlyOnce()
        {
            _service.GetAllTreatments();
            _mock.Verify(r => r.ReadAllTreatments(), Times.Once);
        }

        [Fact]
        public void GetTreatments_NoFilter_ReturnsListOfAllTreatments()
        {
            var expected = new List<Treatment>
            {
                new Treatment {Id = 1, TreatmentName = "Bundfarve", Duration = 120, Price = 800},
                new Treatment {Id = 2, TreatmentName = "Klip", Duration = 45, Price = 400}
            };
            
            _mock.Setup(r => r.ReadAllTreatments())
                .Returns(expected);
            var actual = _service.GetAllTreatments();
            Assert.Equal(expected, actual);
        }
    }
}