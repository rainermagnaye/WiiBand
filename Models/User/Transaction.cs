using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_example.Models.User
{
    // Models/Transaction.cs
    public class Transaction
    {
        public int Id { get; set; }
        public string Promo { get; set; } = "";
        public int NumberOfJumpers { get; set; }
        public int Discounted { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Branch { get; set; } = ""; 


    }




}
