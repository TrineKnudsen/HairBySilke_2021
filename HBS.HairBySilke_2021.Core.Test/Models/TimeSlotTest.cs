using System;
using HBS.HairBySilke_2021.Core.Models;
using Xunit;

namespace HBS.HairBySilke_2021.Core.Test.Models
{
    public class TimeSlotTest
    {
        private readonly TestHelper _helper;

        public TimeSlotTest()
        {
            _helper = new TestHelper();
        }

        [Fact]
        public void TimeSlot_CanBeInitialized()
        {
            Assert.NotNull(_helper.GetTimeSlot());
        }

        [Fact]
        public void TimeSlot_SetId_StoresId()
        {
            var timeSlot = _helper.GetTimeSlot(1);
            Assert.Equal(1, timeSlot.Id);
        }

        [Fact]
        public void TimeSlot_SetStart_StoreStartAsDateTime()
        {
            var timeslot = new TimeSlot();
            timeslot.Start = new DateTime(2022,08,12,12,0,0);
            Assert.Equal(new DateTime(2022,08,12,12,0,0), timeslot.Start);
        }

        [Fact]
        public void TimeSlot_SetEnd_StoresEndAsDateTime()
        {
            var timeslot = new TimeSlot();
            timeslot.End = new DateTime(2022,08,12,13,0,0);
            Assert.Equal(new DateTime(2022,08,12,13,0,0), timeslot.Start);
        }

        [Fact]
        public void TimeSlot_SetDuration_StoresDurationAsTimeSpan()
        {
            var timeslot = new TimeSlot();
            timeslot.Duration = new DateTime(2022,08,12,13,0,0)
                                - new DateTime(2022,08,12,12,0,0);
            Assert.Equal(new DateTime(2022,08,12,13,0,0) - new DateTime(2022,08,12,12,0,0), timeslot.Duration);
        }

        [Fact]
        public void TimeSlot_IsAvailable_IsOfTypeBoolean()
        {
            Assert.True(_helper.GetTimeSlot(1).IsAvailable is Boolean);
        }
    }
}