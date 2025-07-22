namespace app_example.DTOs
{
    // DTOs/TransactionResponse.cs
    public class TransactionResponse
    {
        public int Id { get; set; }
        public string Promo { get; set; } = "";
        public int NumberOfJumpers { get; set; }
        public int Discounted { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Active";
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string Email { get; set; } = "";
        public string TimeRemaining { get; set; } // Real-time countdown string
        public DateTime ExpiresAt { get; set; }  // Used for live countdown
    }



}
