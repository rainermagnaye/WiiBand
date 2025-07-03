namespace app_example.DTOs.User
{
    public class TodaySummary
    {
        public DateTime Date { get; set; }           // The current date
        public int TotalJumpers { get; set; }        // Number of visitors
        public decimal TotalSales { get; set; }      // Sales amount
        public List<TransactionResponse> Transactions { get; set; }

    }

}
