using System;
using HBS.HairBySilke_2021.Core.Models;
using Itenso.TimePeriod;

namespace HBS.HariBySilke_2021.WebApi.DTOs
{
    public class AppointmentDto
    {
        public string TreatmentName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime DateTime { get; set; }
        
        //TODO
    }
}