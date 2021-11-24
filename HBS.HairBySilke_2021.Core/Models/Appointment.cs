namespace HBS.HairBySilke_2021.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Treatment Treatment { get; set; }
        public Customer User { get; set; }
        public int AdminId { get; set; }
        
    }
}