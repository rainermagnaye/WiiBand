namespace app_example.Models.User
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        // Total jumpers booked across all transactions
        public int TotalJumpersBooked { get; set; }

        // One-to-many: A customer can have many transactions
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

}
