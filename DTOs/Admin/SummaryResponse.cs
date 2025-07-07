namespace app_example.DTOs.Admin
{
    public class SummaryResponse
    {
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public string Type { get; set; } = "";
        public decimal TotalSales { get; set; }
        public int TotalJumpers { get; set; }
        public string Branch { get; set; } = "";
    }
}
