namespace app_example.DTOs
{
    public class TodaySummary
    {
        public DateTime Date { get; set; }           // The current date
        public int TotalJumpers { get; set; }        // Number of visitors
        public decimal TotalSales { get; set; }      // Sales amount
        public int ActiveNow { get; set; } // <--- new property

        public List<TransactionResponse> Transactions { get; set; }

    }

}
