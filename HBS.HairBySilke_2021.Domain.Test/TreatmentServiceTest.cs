using System.Collections.Generic;
using System.IO;
using HBS.Domain.IRepositories;
using HBS.Domain.Services;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
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
        [Fact]
        public void TreatmentsService_IsITreatmentsService()
        {
            Assert.True(_service is ITreatmentsService);
        }

        [Fact]
        public void TreatmentService_WithNullTreatmentRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new TreatmentsService(null));
        }
        
        [Fact]
        public void TreatmentService_WithNullTreatmentRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(() =>
                new TreatmentsService(null));
            Assert.Equal("TreatmentRepository cannot be null", exception.Message);
        }

        [Fact]
        public void GetAllTreatments_CallsTreatmentRepositoryReadAllTreatments_ExactlyOnce()
        {
            _service.GetAllTreatments();
            _mock.Verify(r => r.ReadAllTreatments(), Times.Once);
        }

        [Fact]
        public void GetAllTreatments_NoFilter_ReturnsListOfAllTreatments()
        {
            var expectedList = new List<Treatment>
            {
                new Treatment {Id = 1, TreatmentName = "Hårklip", Duration = 60, Price = 200}
            };
            _mock.Setup(r => r.ReadAllTreatments())
                .Returns(expectedList);
            var actualList = _service.GetAllTreatments();
            Assert.Equal(expectedList,actualList);
        }
    }
}