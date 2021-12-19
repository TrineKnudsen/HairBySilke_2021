using System;
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
    public class TimeSlotServiceTest
    {
        private readonly Mock<ITimeSlotRepository> _mock;
        private readonly TimeSlotService _service;

        public TimeSlotServiceTest()
        {
            _mock = new Mock<ITimeSlotRepository>();
            _service = new TimeSlotService(_mock.Object);
        }
        [Fact]
        public void TimeSlotService_IsITimeSlotService()
        {
            Assert.True(_service is ITimeSlotService);
        }

        [Fact]
        public void TimeSlotService_WithNullTimeSlotRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new TimeSlotService(null));
        }
        
        [Fact]
        public void TimeSlotService_WithNullTimeSlotRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(() =>
                new TimeSlotService(null));
            Assert.Equal("TimeSlotRepository cannot be null", exception.Message);
        }

        [Fact]
        public void GetAvailableTimeSlots_CallsTimeSlotRepositoryGetAvailableTimeSlots_ExactlyOnce()
        {
            _service.GetAvailableTimeSlots();
            _mock.Verify(r => r.GetAvailableTimeSlots(), Times.Once);
        }
        
        [Fact]
        public void GetAvailableTimeSlotsByTreatment_CallsTimeSlotRepositoryGetAvailableTimeSlotsByTreatment_ExactlyOnce()
        {
            _service.GetAvailableTimeSlotsByTreatment(100);
            _mock.Verify(r => r.GetAvailableTimeSlotsByTreatment(100), Times.Once);
        }
    }
}