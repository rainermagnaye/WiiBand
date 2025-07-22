using app_example.Data;
using app_example.DTOs;
using app_example.DTOs.User;
using app_example.Models;
using app_example.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_example.Controllers.API.User
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

        // POST: Create Transaction
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction(TransactionCreateRequest dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Promo))
            {
                return BadRequest("Promo is required.");
            }

            if (dto.Discounted > dto.NumberOfJumpers)
            {
                return BadRequest("Discounted jumpers cannot exceed total number of jumpers.");
            }

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

            var promoLower = dto.Promo.Trim().ToLowerInvariant();
            decimal pricePer;

            if (promoLower == "early bird")
                pricePer = 399;
            else if (promoLower == "10hrs multipass")
                pricePer = 3990;
            else if (promoLower == "20hrs multipass")
                pricePer = 7485;
            else
                pricePer = 499;

            decimal total;

            if (promoLower == "10hrs multipass" || promoLower == "20hrs multipass")
            {
                total = dto.NumberOfJumpers * pricePer;
            }
            else
            {
                var discountedCount = dto.Discounted > dto.NumberOfJumpers ? dto.NumberOfJumpers : dto.Discounted;
                var regularCount = dto.NumberOfJumpers - discountedCount;

                var discountedTotal = discountedCount * pricePer * 0.8m;
                var regularTotal = regularCount * pricePer;

                total = discountedTotal + regularTotal;
            }

            total = Math.Round(total, 2);

            var createdAt = DateTime.UtcNow;

            // Directly calculate expiresAt here (1 hour and 5 minutes later)
            var expiresAt = createdAt.AddHours(1).AddMinutes(2);



            var countdown = expiresAt - createdAt;
            if (countdown < TimeSpan.Zero)
                countdown = TimeSpan.Zero;

            var timeRemaining = countdown.ToString(@"hh\:mm\:ss");
            var status = countdown > TimeSpan.Zero ? "Active" : "Finished";

            var today = createdAt.Date;
            var diff = (7 + (today.DayOfWeek - DayOfWeek.Sunday)) % 7;
            var weekStart = today.AddDays(-1 * diff);
            var weekEnd = weekStart.AddDays(6);
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var transaction = new Transaction
            {
                Promo = dto.Promo,
                NumberOfJumpers = dto.NumberOfJumpers,
                Discounted = promoLower.Contains("multipass") ? 0 : dto.Discounted,
                TotalAmount = total,
                Customer = customer,
                Branch = branch,
                CreatedAt = createdAt
            };

            _context.Transactions.Add(transaction);

            await UpsertSummary(today, today, "Daily", total, dto.NumberOfJumpers, branch);
            await UpsertSummary(weekStart, weekEnd, "Weekly", total, dto.NumberOfJumpers, branch);
            await UpsertSummary(monthStart, monthEnd, "Monthly", total, dto.NumberOfJumpers, branch);

            await _context.SaveChangesAsync();

            var response = new TransactionResponse
            {
                Id = transaction.Id,
                Promo = transaction.Promo,
                NumberOfJumpers = transaction.NumberOfJumpers,
                Discounted = transaction.Discounted,
                TotalAmount = transaction.TotalAmount,
                CustomerId = customer.Id,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                ExpiresAt = expiresAt,
                TimeRemaining = timeRemaining,
                Status = status
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

        // GET: View all transactions today
        [HttpGet]
        public async Task<ActionResult<TodaySummary>> GetAllTransactions()
        {
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var branch = user.Branch;
            if (string.IsNullOrWhiteSpace(branch))
                return BadRequest("Your account does not have a branch assigned.");

            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .Where(t =>
                    t.CreatedAt >= today &&
                    t.CreatedAt < tomorrow &&
                    t.Branch == branch)
                .ToListAsync();

            var now = DateTime.UtcNow;

            var transactionResponses = transactions.Select(t =>
            {
                var expiresAt = t.CreatedAt.AddHours(1).AddMinutes(2); // Use your consistent 1-minute expiry

                var countdown = expiresAt - now;

                var timeRemaining = countdown > TimeSpan.Zero
                    ? countdown.ToString(@"hh\:mm\:ss")
                    : "00:00:00";

                var status = countdown > TimeSpan.Zero ? "Active" : "Finished";

                return new TransactionResponse
                {
                    Id = t.Id,
                    Promo = t.Promo,
                    NumberOfJumpers = t.NumberOfJumpers,
                    Discounted = t.Discounted,
                    TotalAmount = t.TotalAmount,
                    ExpiresAt = expiresAt,
                    TimeRemaining = timeRemaining,
                    Status = status,
                    CustomerId = t.CustomerId,
                    CustomerName = t.Customer?.CustomerName ?? "",
                    Email = t.Customer?.Email ?? ""
                };
            }).ToList();

            var totalJumpers = transactions.Sum(t => t.NumberOfJumpers);
            var totalSales = transactions.Sum(t => t.TotalAmount);

            // Sum NumberOfJumpers for only active transactions
            var activeNowCount = transactionResponses
                .Where(tr => tr.Status == "Active")
                .Sum(tr => tr.NumberOfJumpers);

            var response = new TodaySummary
            {
                Date = today,
                TotalJumpers = totalJumpers,
                TotalSales = totalSales,
                ActiveNow = activeNowCount,
                Transactions = transactionResponses
            };

            return Ok(response);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponse>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
                return NotFound();

            DateTime expiresAt = transaction.CreatedAt.AddHours(1).AddMinutes(2);

            var now = DateTime.UtcNow;
            var countdown = expiresAt - now;

            var timeRemaining = countdown > TimeSpan.Zero
                ? countdown.ToString(@"hh\\:mm\\:ss")
                : "00:00:00";

            var status = countdown > TimeSpan.Zero ? "Active" : "Finished";

            return new TransactionResponse
            {
                Id = transaction.Id,
                Promo = transaction.Promo,
                NumberOfJumpers = transaction.NumberOfJumpers,
                Discounted = transaction.Discounted,
                TotalAmount = transaction.TotalAmount,
                CustomerId = transaction.Customer.Id,
                CustomerName = transaction.Customer.CustomerName,
                Email = transaction.Customer.Email,
                ExpiresAt = expiresAt,
                TimeRemaining = timeRemaining,
                Status = status
            };
        }



    }
}
