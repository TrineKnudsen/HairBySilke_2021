using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.Core.Test
{
    public class TestHelper
    {
        public Treatment GetTreatment(int id = 1)
        {
            return new Treatment
            {
                Id = id
            };
        }

        public Customer GetCustomer(int id = 1)
        {
            return new Customer
            {
                Id = id
            };
        }

        public TimeSlot GetTimeSlot(int id = 1)
        {
            return new TimeSlot
            {
                Id = id
            };
        }
    }
}