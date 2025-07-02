//using app_example.Data;
//using app_example.DTOs;
//using app_example.Models;
//using app_example.Models.User;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace app_example.Controllers.API.User
//{
//    [ApiController]
//    [Route("api/user/[controller]")]
//    public class CustomerController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public CustomerController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // POST /api/user/customer
//        public async Task<ActionResult<CustomerResponse>> CreateCustomer(CustomerCreateRequest dto)
//        {
//            var exists = await _context.Customers.AnyAsync(c => c.Email == dto.Email);
//            if (exists)
//                return BadRequest("Customer already exists.");

//            var customer = new Customer
//            {
//                CustomerName = dto.CustomerName,
//                Email = dto.Email,
//                TotalJumpersBooked = 0
//            };

//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();

//            var response = new CustomerResponse
//            {
//                Id = customer.Id,
//                CustomerName = customer.CustomerName,
//                Email = customer.Email,
//                TotalJumpersBooked = customer.TotalJumpersBooked
//            };

//            return CreatedAtAction(nameof(GetCustomer), new { id = response.Id }, response);
//        }

//        // GET: api/user/customer/   by [id]
//        [HttpGet("{id}")]
//        public async Task<ActionResult<CustomerResponse>> GetCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);

//            if (customer == null)
//                return NotFound();

//            var response = new CustomerResponse
//            {
//                Id = customer.Id,
//                CustomerName = customer.CustomerName,
//                Email = customer.Email,
//                TotalJumpersBooked = customer.TotalJumpersBooked
//            };

//            return Ok(response);
//        }


//    }
//}
