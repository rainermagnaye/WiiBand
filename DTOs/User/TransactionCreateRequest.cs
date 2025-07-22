// DTOs/TransactionCreateRequest.cs

using System.ComponentModel.DataAnnotations;

namespace app_example.DTOs.User
{
    public class TransactionCreateRequest
    {
        [Required(ErrorMessage = "Promo is required.")]
        public string Promo { get; set; } = "";

        [Range(1, 100, ErrorMessage = "Number of jumpers must be atleast 1.")]
        public int NumberOfJumpers { get; set; }

        public int Discounted { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
        public string CustomerName { get; set; } = "";

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = "";
    }
}
