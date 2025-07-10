namespace app_example.Models.Admin
{
    public class ForecastedData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PredictedVisitors { get; set; }
        public decimal PredictedSales { get; set; }
    }

}
