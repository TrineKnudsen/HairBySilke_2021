using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class AppointmentEntity
    {
        public int Id { get; set; }
        
        public List<TreatmentEntity> Treatments { get; set; }
        
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }
        
        public int AdminId { get; set; }
        public AdminEntity Admin { get; set; }
        
        
    }
}