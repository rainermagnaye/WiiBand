using Microsoft.ML.Data;

namespace app_example.Models.Admin
{
    public class DailyParkSalesData
    {
        [LoadColumn(0)]
        public float OverallPaxQty { get; set; }

        [LoadColumn(1)]
        public float OverallPaxAmount { get; set; }
    }
}
