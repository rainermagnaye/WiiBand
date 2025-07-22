using app_example.Data;
using app_example.DTOs;
using app_example.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_example.Controllers.API.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        private DateTime GetExpiresAt(DateTime createdAt)
        {
            return createdAt.AddHours(1).AddMinutes(2);
        }

        // GET: api/admin/transaction/today?branch=...
        [HttpGet("today")]
        public async Task<ActionResult<TodaySummary>> GetTodaySummary([FromQuery] string branch)
        {
            if (string.IsNullOrWhiteSpace(branch))
                return BadRequest("Branch is required.");

            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            var now = DateTime.UtcNow;

            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .Where(t =>
                    t.CreatedAt >= today &&
                    t.CreatedAt < tomorrow &&
                    t.Branch == branch)
                .ToListAsync();

            var transactionResponses = transactions.Select(t =>
            {
                var expiresAt = GetExpiresAt(t.CreatedAt);
                var countdown = expiresAt - now;
                var status = countdown > TimeSpan.Zero ? "Active" : "Finished";
                var timeRemaining = countdown > TimeSpan.Zero
                    ? countdown.ToString(@"hh\:mm\:ss")
                    : "00:00:00";

                return new TransactionResponse
                {
                    Id = t.Id,
                    Promo = t.Promo,
                    NumberOfJumpers = t.NumberOfJumpers,
                    Discounted = t.Discounted,
                    TotalAmount = t.TotalAmount,
                    CustomerId = t.CustomerId,
                    CustomerName = t.Customer?.CustomerName ?? "",
                    Email = t.Customer?.Email ?? "",
                    ExpiresAt = expiresAt,
                    TimeRemaining = timeRemaining,
                    Status = status
                };
            }).ToList();

            var totalJumpers = transactionResponses.Sum(t => t.NumberOfJumpers);
            var totalSales = transactionResponses.Sum(t => t.TotalAmount);
            var activeNow = transactionResponses
                .Where(t => t.Status == "Active")
                .Sum(t => t.NumberOfJumpers);

            var summary = new TodaySummary
            {
                Date = today,
                TotalJumpers = totalJumpers,
                TotalSales = totalSales,
                ActiveNow = activeNow,
                Transactions = transactionResponses
            };

            return Ok(summary);
        }
    }
}
