namespace FinalAssesment.Models.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
