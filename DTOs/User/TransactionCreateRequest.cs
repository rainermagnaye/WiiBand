using System.ComponentModel.DataAnnotations;

namespace app_example.DTOs.User
{
    // DTOs/TransactionCreateRequest.cs
    public class TransactionCreateRequest
    {
        public string Promo { get; set; } = "";

        [Range(1, 100, ErrorMessage = "Number of jumpers must be at least 1.")]
        public int NumberOfJumpers { get; set; }
        public bool IsDiscounted { get; set; }
        public string CustomerName { get; set; } = "";
        public string Email { get; set; } = "";
    }


}
