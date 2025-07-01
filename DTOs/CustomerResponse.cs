namespace app_example.DTOs
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TotalJumpersBooked { get; set; }
    }
}
