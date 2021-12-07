using System;

namespace HBS.HairBySilke_2021.Core.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}