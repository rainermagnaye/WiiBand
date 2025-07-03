using app_example.Data;
using app_example.DTOs.User;
using app_example.Models;
using app_example.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_example.Controllers.API
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Create a Transaction
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction(TransactionCreateRequest dto)
        {
            // Validate promo
            if (string.IsNullOrWhiteSpace(dto.Promo))
            {
                return BadRequest("Promo is required.");
            }

            // Get current user and branch
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var branch = user.Branch;
            if (string.IsNullOrWhiteSpace(branch))
            {
                return BadRequest("Your account does not have a branch assigned.");
            }

            // Find or create customer
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == dto.Email);

            if (customer == null)
            {
                customer = new Customer
                {
                    CustomerName = dto.CustomerName,
                    Email = dto.Email,
                    TotalJumpersBooked = dto.NumberOfJumpers
                };
                _context.Customers.Add(customer);
            }
            else
            {
                customer.TotalJumpersBooked += dto.NumberOfJumpers;
            }

            // Compute pricing
            var promoLower = dto.Promo.ToLowerInvariant();
            var pricePer = promoLower == "early bird" ? 399 : 499;
            decimal total = dto.NumberOfJumpers * pricePer;
            if (dto.IsDiscounted)
            {
                total *= 0.8m;
            }
            total = Math.Round(total, 2);

            var createdAt = DateTime.UtcNow;
            var today = createdAt.Date;

            // Week start (Monday) and end (Sunday)
            var diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            var weekStart = today.AddDays(-1 * diff);
            var weekEnd = weekStart.AddDays(6);

            // Month start and end
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            // Create transaction
            var transaction = new Transaction
            {
                Promo = dto.Promo,
                NumberOfJumpers = dto.NumberOfJumpers,
                IsDiscounted = dto.IsDiscounted,
                TotalAmount = total,
                Customer = customer,
                Branch = branch,
                CreatedAt = createdAt
            };

            _context.Transactions.Add(transaction);

            // Upsert summaries per branch
            await UpsertSummary(today, today, "Daily", total, dto.NumberOfJumpers, branch);
            await UpsertSummary(weekStart, weekEnd, "Weekly", total, dto.NumberOfJumpers, branch);
            await UpsertSummary(monthStart, monthEnd, "Monthly", total, dto.NumberOfJumpers, branch);

            // Save all changes
            await _context.SaveChangesAsync();

            var response = new TransactionResponse
            {
                Id = transaction.Id,
                Promo = transaction.Promo,
                NumberOfJumpers = transaction.NumberOfJumpers,
                IsDiscounted = transaction.IsDiscounted,
                TotalAmount = transaction.TotalAmount,
                CustomerId = customer.Id,
                CustomerName = customer.CustomerName,
                Email = customer.Email
            };

            return CreatedAtAction(nameof(GetTransaction), new { id = response.Id }, response);
        }

        private async Task UpsertSummary(DateTime start, DateTime end, string type, decimal amount, int jumpers, string branch)
        {
            var normalizedType = type.Trim().ToUpperInvariant();

            var summary = await _context.Summaries
                .FirstOrDefaultAsync(s =>
                    s.PeriodStart == start &&
                    s.PeriodEnd == end &&
                    s.Type.ToUpper() == normalizedType &&
                    s.Branch == branch);

            if (summary == null)
            {
                summary = new Summary
                {
                    PeriodStart = start,
                    PeriodEnd = end,
                    Type = normalizedType,
                    TotalSales = amount,
                    TotalJumpers = jumpers,
                    Branch = branch
                };
                _context.Summaries.Add(summary);
            }
            else
            {
                summary.TotalSales += amount;
                summary.TotalJumpers += jumpers;
            }
        }

        // GET: api/user/transaction
        [HttpGet]
        public async Task<ActionResult<TodaySummary>> GetAllTransactions()
        {
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);

            // Get current user and branch
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var branch = user.Branch;
            if (string.IsNullOrWhiteSpace(branch))
            {
                return BadRequest("Your account does not have a branch assigned.");
            }

            // Fetch transactions only for this branch
            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .Where(t =>
                    t.CreatedAt >= today &&
                    t.CreatedAt < tomorrow &&
                    t.Branch == branch)
                .ToListAsync();

            var totalJumpers = transactions.Sum(t => t.NumberOfJumpers);
            var totalSales = transactions.Sum(t => t.TotalAmount);

            var response = new TodaySummary
            {
                Date = today,
                TotalJumpers = totalJumpers,
                TotalSales = totalSales,
                Transactions = transactions.Select(t => new TransactionResponse
                {
                    Id = t.Id,
                    Promo = t.Promo,
                    NumberOfJumpers = t.NumberOfJumpers,
                    IsDiscounted = t.IsDiscounted,
                    TotalAmount = t.TotalAmount,
                    CustomerId = t.CustomerId,
                    CustomerName = t.Customer?.CustomerName ?? "",
                    Email = t.Customer?.Email ?? ""
                }).ToList()
            };

            return Ok(response);
        }

        // GET: Get Transaction by [id]
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponse>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null) return NotFound();

            return new TransactionResponse
            {
                Id = transaction.Id,
                Promo = transaction.Promo,
                NumberOfJumpers = transaction.NumberOfJumpers,
                IsDiscounted = transaction.IsDiscounted,
                TotalAmount = transaction.TotalAmount,
                CustomerId = transaction.Customer.Id,
                CustomerName = transaction.Customer.CustomerName,
                Email = transaction.Customer.Email
            };
        }
    }
}
