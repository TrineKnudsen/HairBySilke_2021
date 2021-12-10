using System;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public DateTime Start { get; set; }
        public CustomerDTO Customer { get; set; }
        
    }
}