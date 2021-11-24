using System.Collections.Generic;

namespace HBS.HairBySilke_2021.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}