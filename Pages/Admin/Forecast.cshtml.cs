//using app_example.Models.Admin;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using MLModel_ConsoleApp1; // <-- Replace with your actual namespace

//namespace app_example.Pages.Admin
//{
//    public class ForecastModel : PageModel
//    {
//        // Predicted daily values
//        public List<float> ForecastedValues { get; set; } = new();

//        // Aggregated totals
//        public decimal WeeklyMaxTotal { get; set; }
//        public decimal MonthlyMaxTotal { get; set; }
//        public decimal QuarterlyMaxTotal { get; set; }
//        public decimal AnnualMaxTotal { get; set; }

//        public List<decimal> WeeklyTotals { get; set; } = new();
//        public List<decimal> MonthlyTotals { get; set; } = new();
//        public List<decimal> QuarterlyTotals { get; set; } = new();
//        public decimal AnnualTotal { get; set; }

//        public double RSquared => ModelMetrics.RSquared;
//        public double MAE => ModelMetrics.MAE;
//        public double RMSE => ModelMetrics.RMSE;


//        //public void OnGet()
//        //{
//        //    // Call the generated ML.NET method (adjust class name if yours is different)
//        //    var prediction = MLModel.Predict(null, 365); // 365 = forecast horizon (days)

//        //    // Save daily predictions as list
//        //    ForecastedValues = prediction.OverallPaxAmount.ToList();

//        //    // Compute aggregated max totals
//        //    WeeklyMaxTotal = ForecastedValues.Take(7).Sum(v => (decimal)v);
//        //    MonthlyMaxTotal = ForecastedValues.Take(30).Sum(v => (decimal)v);
//        //    QuarterlyMaxTotal = ForecastedValues.Take(90).Sum(v => (decimal)v);
//        //    AnnualMaxTotal = ForecastedValues.Take(365).Sum(v => (decimal)v);
//        //}

//        public void OnGet()
//        {
//            var prediction = MLModel.Predict(null, 365);
//            ForecastedValues = prediction.OverallPaxAmount.ToList();

//            // Weekly: sum of each week (7 days)
//            for (int i = 0; i < 365; i += 7)
//            {
//                var weekTotal = ForecastedValues.Skip(i).Take(7).Sum(v => (decimal)v);
//                WeeklyTotals.Add(weekTotal);
//            }

//            // Monthly: sum of each month (approx every 30 days)
//            for (int i = 0; i < 365; i += 30)
//            {
//                var monthTotal = ForecastedValues.Skip(i).Take(30).Sum(v => (decimal)v);
//                MonthlyTotals.Add(monthTotal);
//            }

//            // Quarterly: sum of each quarter (90 days)
//            for (int i = 0; i < 365; i += 90)
//            {
//                var quarterTotal = ForecastedValues.Skip(i).Take(90).Sum(v => (decimal)v);
//                QuarterlyTotals.Add(quarterTotal);
//            }

//            // Annual total
//            AnnualTotal = ForecastedValues.Sum(v => (decimal)v);
//        }
//    }
//}

using app_example.Models.Admin;
using app_example.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using MLModel_ConsoleApp1; // your generated ML.NET namespace

namespace app_example.Pages.Admin
{
    public class ForecastModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ForecastModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Predicted daily values from ML.NET model
        public List<float> ForecastedValues { get; set; } = new();

        // Aggregated totals
        public List<decimal> WeeklyTotals { get; set; } = new();
        public List<decimal> MonthlyTotals { get; set; } = new();
        public List<decimal> QuarterlyTotals { get; set; } = new();
        public decimal AnnualTotal { get; set; }

        // Optional: max totals
        public decimal WeeklyMaxTotal { get; set; }
        public decimal MonthlyMaxTotal { get; set; }
        public decimal QuarterlyMaxTotal { get; set; }
        public decimal AnnualMaxTotal { get; set; }

        // Accuracy metrics (if you have ModelMetrics)
        public double RSquared => ModelMetrics.RSquared;
        public double MAE => ModelMetrics.MAE;
        public double RMSE => ModelMetrics.RMSE;

        // GET: load prediction and compute aggregates
        public void OnGet()
        {
            // Example: call ML.NET Predict method
            // Replace with correct call if your generated code differs
            var prediction = MLModel.Predict(null, 365);
            ForecastedValues = prediction.OverallPaxAmount_UB.ToList();

            // Aggregate predictions
            WeeklyTotals = ForecastedValues.Chunk(7)
                            .Select(week => week.Sum(v => (decimal)v)).ToList();

            MonthlyTotals = ForecastedValues.Chunk(30)
                            .Select(month => month.Sum(v => (decimal)v)).ToList();

            QuarterlyTotals = ForecastedValues.Chunk(90)
                            .Select(q => q.Sum(v => (decimal)v)).ToList();

            AnnualTotal = ForecastedValues.Sum(v => (decimal)v);

            // Max totals
            WeeklyMaxTotal = WeeklyTotals.Max();
            MonthlyMaxTotal = MonthlyTotals.Max();
            QuarterlyMaxTotal = QuarterlyTotals.Max();
            AnnualMaxTotal = AnnualTotal;
        }

        // POST: generate simulated data
        public async Task<IActionResult> OnPostGenerateSimulatedDataAsync()
        {
            await GenerateSimulatedDataAsync();
            return RedirectToPage(); // refresh page
        }


        // Rule-based simulation: 1-year of daily sales data
        private async Task GenerateSimulatedDataAsync()
        {
            var random = new Random();
            var startDate = new DateTime(2022, 8, 1);
            var endDate = startDate.AddDays(365);

            // Remove old data in that date range
            var oldData = _context.DailyParkSales.Where(d => d.Date >= startDate && d.Date < endDate);
            _context.DailyParkSales.RemoveRange(oldData);
            await _context.SaveChangesAsync();

            decimal baseVisitors = 160;

            for (int day = 0; day < 365; day++)
            {
                var date = startDate.AddDays(day);
                var dayOfWeek = date.DayOfWeek.ToString();

                // Trend & seasonality
                decimal trendFactor = 1 + (day / 7) * 0.001m;
                decimal weekendFactor = (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) ? 1.2m : 1.0m;
                decimal monthFactor = date.Month switch
                {
                    12 => 1.5m,
                    4 => 0.8m,
                    _ => 1.0m
                };
                decimal randomFactor = 1 + ((decimal)(random.NextDouble() * 0.1) - 0.05m);

                int visitors = (int)(baseVisitors * trendFactor * weekendFactor * monthFactor * randomFactor);

                // Split into ticket types
                int generalAdmission = (int)(visitors * 0.6);
                int extendedHour = (int)(visitors * 0.1);
                int pwdAdmission = (int)(visitors * 0.05);
                int earlyJump = (int)(visitors * 0.15);
                int tenHourPass = (int)(visitors * 0.02);
                int twentyHourPass = (int)(visitors * 0.01);

                // Compute total sales using prices
                decimal simulatedSales =
                    (generalAdmission * 499m) +
                    (extendedHour * 399m) + 
                    (pwdAdmission * 499m) +
                    (earlyJump * 399m) +
                    (tenHourPass * 3990m) +
                    (twentyHourPass * 7485m);

                _context.DailyParkSales.Add(new DailyParkSales
                {
                    Date = date,
                    DayOfWeek = dayOfWeek,
                    GeneralAdmission = generalAdmission,
                    ExtendedHour = extendedHour,
                    PWDGeneralAdmission = pwdAdmission,
                    EarlyJump = earlyJump,
                    TenHourMultipass = tenHourPass,
                    TwentyHourMultipass = twentyHourPass,
                    OverallPaxQty = visitors,
                    OverallPaxAmount = Math.Round(simulatedSales, 2)
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}

