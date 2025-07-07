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

        // GET: api/admin/transaction/today?branch=...
        [HttpGet("today")]
        public async Task<ActionResult<TodaySummary>> GetTodaySummary([FromQuery] string branch)
        {
            if (string.IsNullOrWhiteSpace(branch))
                return BadRequest("Branch is required.");

            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);

            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .Where(t =>
                    t.CreatedAt >= today &&
                    t.CreatedAt < tomorrow &&
                    t.Branch == branch)
                .ToListAsync();

            var response = new TodaySummary
            {
                Date = today,
                TotalJumpers = transactions.Sum(t => t.NumberOfJumpers),
                TotalSales = transactions.Sum(t => t.TotalAmount),
                Transactions = transactions.Select(t => new TransactionResponse
                {
                    Id = t.Id,
                    CustomerName = t.Customer?.CustomerName ?? "",
                    Email = t.Customer?.Email ?? "",
                    Promo = t.Promo,
                    NumberOfJumpers = t.NumberOfJumpers,
                    IsDiscounted = t.IsDiscounted,
                    TotalAmount = t.TotalAmount,
                    CustomerId = t.CustomerId,
                }).ToList()
            };

            return Ok(response);
        }
    }
}
