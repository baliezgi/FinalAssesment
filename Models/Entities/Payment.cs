namespace FinalAssesment.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        
        public int ExpenseId { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
