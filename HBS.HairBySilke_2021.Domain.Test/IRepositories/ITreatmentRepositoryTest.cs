using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using Moq;
using Xunit;

namespace HBS.HairBySilke_2021.Domain.Test
{
    public class ITreatmentRepositoryTest
    {
        [Fact]
        public void ITreatmentRepository_IsAvailable()
        {
            var repository = new Mock<ITreatmentsRepository>().Object;
            Assert.NotNull(repository);
        }

        [Fact]
        public void ReadAllTreatments_NoParams_ReturnsAListOfAllTreatments()
        {
            var mock = new Mock<ITreatmentsRepository>();
            var fakeList = new List<Treatment>();
            mock.Setup(s => s.ReadAllTreatments())
                .Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.ReadAllTreatments());
        }
    }
}