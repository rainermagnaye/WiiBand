//using app_example.Data;
//using app_example.Models.User;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace app_example.Controllers.API.User
//{
//    [ApiController]
//    [Route("api/user/[controller]")]
//    public class TransactionController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public TransactionController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // POST: api/user/transaction
//        [HttpPost]
//        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            // Find existing customer by email
//            var customer = await _context.Customers
//                .FirstOrDefaultAsync(c => c.Email == transaction.Customer.Email);

//            if (customer == null)
//            {
//                // Create new customer
//                customer = transaction.Customer;
//                customer.TotalJumpersBooked = transaction.NumberOfJumpers;
//                _context.Customers.Add(customer);
//            }
//            else
//            {
//                // Update existing customer
//                customer.TotalJumpersBooked += transaction.NumberOfJumpers;
//            }

//            // Compute total based on promo
//            decimal pricePerJumper = transaction.Promo == "EarlyBird" ? 399 : 499;
//            transaction.TotalAmount = pricePerJumper * transaction.NumberOfJumpers;

//            // Link customer
//            transaction.Customer = customer;

//            _context.Transactions.Add(transaction);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
//        }

//        // GET: api/user/transaction
//        [HttpGet]
//        public async Task<IActionResult> GetAllTransactions()
//        {
//            var transactions = await _context.Transactions
//                .Include(t => t.Customer)
//                .ToListAsync();

//            return Ok(transactions);
//        }

//        // GET: api/user/transaction/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetTransactionById(int id)
//        {
//            var transaction = await _context.Transactions
//                .Include(t => t.Customer)
//                .FirstOrDefaultAsync(t => t.Id == id);

//            if (transaction == null)
//                return NotFound();

//            return Ok(transaction);
//        }
//    }
//}


using app_example.Data;
using app_example.DTOs;
using app_example.Models;
using app_example.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_example.Controllers.API.User
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: Create a Transaction
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction(TransactionCreateRequest dto)
        {
            // Try to find customer by email
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == dto.Email);

            if (customer == null)
            {
                // If not found, create new
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
                // Update existing
                customer.TotalJumpersBooked += dto.NumberOfJumpers;
            }

            // Compute pricing
            var pricePer = dto.Promo.ToLower() == "early bird" ? 399 : 499;
            decimal total = dto.NumberOfJumpers * pricePer;
            if (dto.IsDiscounted) total *= 0.8m;

            // Create transaction
            var transaction = new Transaction
            {
                Promo = dto.Promo,
                NumberOfJumpers = dto.NumberOfJumpers,
                IsDiscounted = dto.IsDiscounted,
                TotalAmount = total,
                Customer = customer,
                CreatedAt = DateTime.UtcNow // Make sure DateCreated is populated

            };

            _context.Transactions.Add(transaction);
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
                Email = customer.Email,
            };

            return CreatedAtAction(nameof(GetTransaction), new { id = response.Id }, response);
        }

        // GET: today summary 
        [HttpGet("today-summary")]
        public async Task<ActionResult<TodaySummary>> GetTodaySummary()
        {
            var today = DateTime.UtcNow.Date;

            var todaysTransactions = await _context.Transactions
                .Where(t => t.CreatedAt.Date == today)
                .ToListAsync();

            var summary = new TodaySummary
            {
                TotalJumpers = todaysTransactions.Sum(t => t.NumberOfJumpers),
                TotalSales = todaysTransactions.Sum(t => t.TotalAmount)
            };

            return Ok(summary);
        }


        // GET: api/user/transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetAllTransactions()
        {
            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .ToListAsync();

            // Map to DTOs
            var response = transactions.Select(t => new TransactionResponse
            {
                Id = t.Id,
                Promo = t.Promo,
                NumberOfJumpers = t.NumberOfJumpers,
                IsDiscounted = t.IsDiscounted,
                TotalAmount = t.TotalAmount,
                CustomerId = t.CustomerId,
                CustomerName = t.Customer?.CustomerName ?? "",
                Email = t.Customer?.Email ?? ""
            });

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
