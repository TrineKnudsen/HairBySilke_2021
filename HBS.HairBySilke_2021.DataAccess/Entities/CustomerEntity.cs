using System.Collections.Generic;

namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public List<AppointmentEntity> Appointments { get; set; }
    }
}