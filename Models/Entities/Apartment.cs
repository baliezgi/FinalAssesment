namespace FinalAssesment.Models.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string BlokInfo { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }



        public User User { get; set; }

        public Payment Payment { get; set; }


    }
}
