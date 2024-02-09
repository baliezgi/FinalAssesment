using System.Numerics;

namespace FinalAssesment.Models.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string FullName { get; set; }

        public string TcNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Usertype { get; set; }
        
        public int ApartmentId { get; set; }
        public  Apartment Apartment { get; set; }
    }
}
