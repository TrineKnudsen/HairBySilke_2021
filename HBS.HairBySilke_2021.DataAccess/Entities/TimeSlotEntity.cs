using Itenso.TimePeriod;

namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class TimeSlotEntity
    {
        public int Id { get; set; }
        public TimeRange TimeRange { get; set; }
        public bool IsAvailable { get; set; }
    }
}