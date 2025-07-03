namespace app_example.Models
{
    public class Summary
    {
        public int Id { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public string Type { get; set; } // Daily, Weekly, Monthly
        public decimal TotalSales { get; set; }
        public int TotalJumpers { get; set; }
        public string Branch { get; set; } // 🟢 Add this

    }
}
