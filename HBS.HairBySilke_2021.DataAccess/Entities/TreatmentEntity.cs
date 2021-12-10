namespace HBS.HairBySilke_2021.DataAccess.Entities
{
    public class TreatmentEntity
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public int Price { get; set; }

        public int Duration { get; set; }
        //public int AppointmentId { get; set; }
        //public AppointmentEntity Appointment { get; set; }

    }
}