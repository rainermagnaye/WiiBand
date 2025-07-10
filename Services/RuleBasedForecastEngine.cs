using app_example.Data;            // replace with your actual namespace for DbContext
using app_example.Models;          // replace with your actual namespace for DailyParkSales
using app_example.Models.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_example.Services
{
    public class RuleBasedForecastEngine
    {
        private readonly ApplicationDbContext _context;

        public RuleBasedForecastEngine(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task GenerateAndSaveOneYearData()
        {
            var random = new Random();
            var startDate = new DateTime(2022, 8, 1);
            var data = new List<DailyParkSales>();

            for (int i = 0; i < 365; i++)
            {
                var date = startDate.AddDays(i);
                var dayOfWeek = date.DayOfWeek.ToString();
                bool isWeekend = dayOfWeek == "Saturday" || dayOfWeek == "Sunday";

                // Base numbers with weekend boost
                int generalAdmission = isWeekend ? random.Next(180, 250) : random.Next(120, 180);
                int extendedHour = random.Next(5, 20);
                int pwdGeneral = random.Next(2, 10);
                int earlyJump = random.Next(3, 15);

                // Total visitors
                int totalVisitors = generalAdmission + extendedHour + pwdGeneral + earlyJump;

                // Ticket prices
                decimal priceGeneral = 100m;
                decimal priceExtended = 50m;
                decimal pricePwd = 80m;
                decimal priceEarly = 60m;

                decimal totalAmount =
                    (generalAdmission * priceGeneral) +
                    (extendedHour * priceExtended) +
                    (pwdGeneral * pricePwd) +
                    (earlyJump * priceEarly);

                var daily = new DailyParkSales
                {
                    Date = date,
                    DayOfWeek = dayOfWeek,
                    GeneralAdmission = generalAdmission,
                    ExtendedHour = extendedHour,
                    PWDGeneralAdmission = pwdGeneral,
                    EarlyJump = earlyJump,
                    OverallPaxQty = totalVisitors,
                    OverallPaxAmount = Math.Round(totalAmount, 2)
                };

                data.Add(daily);
            }

            // Optional: clear old data first
            // _context.DailyParkSales.RemoveRange(_context.DailyParkSales);

            // Save simulated data
            _context.DailyParkSales.AddRange(data);
            await _context.SaveChangesAsync();
        }
    }
}
