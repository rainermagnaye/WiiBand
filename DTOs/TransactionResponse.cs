namespace app_example.DTOs
{
    // DTOs/TransactionResponse.cs
    public class TransactionResponse
    {
        public int Id { get; set; }
        public string Promo { get; set; }
        public int NumberOfJumpers { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime CreatedAt { get; set; }

    }

}
