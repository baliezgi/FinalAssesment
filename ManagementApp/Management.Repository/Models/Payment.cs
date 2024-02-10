using Microsoft.EntityFrameworkCore;

namespace Management.Repository.Models
{
    public class Payment
    {
        public int Id { get; set; }
        //public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
       
        [Precision(18,2)]
        public decimal Amount { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }

        //public int ApartmentId { get; set; }
        //public Apartment Apartment { get; set; }
    }
}
