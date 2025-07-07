using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app_example.Data;
using app_example.Models;

namespace app_example.Controllers.API.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class SummaryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SummaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET /api/admin/summary?type=Daily&branch=Branch1
        [HttpGet]
        public async Task<ActionResult<List<Summary>>> GetSummaries(
            [FromQuery] string type = "Daily",
            [FromQuery] string? branch = null)
        {
            var normalizedType = type.Trim().ToUpperInvariant();

            if (!new[] { "DAILY", "WEEKLY", "MONTHLY" }.Contains(normalizedType))
            {
                return BadRequest("Invalid summary type. Must be Daily, Weekly, or Monthly.");
            }

            var query = _context.Summaries
                .Where(s => s.Type.ToUpper() == normalizedType);

            if (!string.IsNullOrWhiteSpace(branch))
            {
                query = query.Where(s => s.Branch == branch);
            }

            var results = await query
                .OrderByDescending(s => s.PeriodStart)
                .ToListAsync();

            return Ok(results);
        }

    }
}
