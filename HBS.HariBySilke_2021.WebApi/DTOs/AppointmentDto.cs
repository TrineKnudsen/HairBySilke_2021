using System;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AdminId { get; set; }
        public DateTime DateTime { get; set; }
        
        //TODO
    }
}