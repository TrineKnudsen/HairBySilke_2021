using System;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public int Price { get; set; }
        public int AppointmentId { get; set; }
    }
}