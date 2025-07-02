//using app_example.Data;
//using app_example.Models.User;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace app_example.Controllers.API.User
//{
//    [ApiController]
//    [Route("api/user/[controller]")]
//    public class EventController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public EventController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        /// Book a new event.
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] Event newEvent)
//        {
//            if (newEvent == null ||
//                string.IsNullOrWhiteSpace(newEvent.Name) ||
//                string.IsNullOrWhiteSpace(newEvent.Email) ||
//                newEvent.Duration <= 0 ||
//                newEvent.Jumpers <= 0)
//            {
//                return BadRequest("Invalid booking data.");
//            }

//            // 🧠 Compute StartTime and EndTime
//            var startDateTime = newEvent.Date.Date + newEvent.Time;
//            newEvent.StartTime = startDateTime;
//            newEvent.EndTime = startDateTime.AddMinutes(newEvent.Duration);

//            // Save to DB
//            _context.Events.Add(newEvent);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
//        }

//        /// Get all booked events.
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var events = await _context.Events.ToListAsync();
//            return Ok(events);
//        }

//        /// Get event by ID.
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var ev = await _context.Events.FindAsync(id);
//            if (ev == null)
//                return NotFound();

//            return Ok(ev);
//        }

//        /// <summary>
//        /// Update (edit) an existing event.
//        /// </summary>
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] Event updatedEvent)
//        {
//            if (updatedEvent == null ||
//                string.IsNullOrWhiteSpace(updatedEvent.Name) ||
//                string.IsNullOrWhiteSpace(updatedEvent.Email) ||
//                updatedEvent.Duration <= 0 ||
//                updatedEvent.Jumpers <= 0)
//            {
//                return BadRequest("Invalid data.");
//            }

//            var existingEvent = await _context.Events.FindAsync(id);
//            if (existingEvent == null)
//                return NotFound();

//            // Update fields
//            existingEvent.Name = updatedEvent.Name;
//            existingEvent.Email = updatedEvent.Email;
//            existingEvent.Date = updatedEvent.Date;
//            existingEvent.Time = updatedEvent.Time;
//            existingEvent.Duration = updatedEvent.Duration;
//            existingEvent.Jumpers = updatedEvent.Jumpers;
//            existingEvent.AddonsData = updatedEvent.AddonsData;

//            // Recompute StartTime and EndTime
//            var startDateTime = updatedEvent.Date.Date + updatedEvent.Time;
//            existingEvent.StartTime = startDateTime;
//            existingEvent.EndTime = startDateTime.AddMinutes(updatedEvent.Duration);

//            await _context.SaveChangesAsync();

//            return Ok(existingEvent);
//        }

//        /// Delete event by ID.
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var existingEvent = await _context.Events.FindAsync(id);
//            if (existingEvent == null)
//                return NotFound();

//            _context.Events.Remove(existingEvent);
//            await _context.SaveChangesAsync();

//            return NoContent(); // 204 status
//        }
//    }
//}


using app_example.Data;
using app_example.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_example.Controllers.API.User
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// Book a new event.
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] Event newEvent)
        //{
        //    if (newEvent == null ||
        //        string.IsNullOrWhiteSpace(newEvent.Name) ||
        //        string.IsNullOrWhiteSpace(newEvent.Email) ||
        //        newEvent.Duration <= 0 ||
        //        newEvent.Jumpers <= 0)
        //    {
        //        return BadRequest("Invalid booking data.");
        //    }

        //    // 🧠 Compute StartTime and EndTime
        //    var startDateTime = newEvent.Date.Date + newEvent.Time;
        //    newEvent.StartTime = startDateTime;
        //    newEvent.EndTime = startDateTime.AddHours(newEvent.Duration); // Duration now in hours

        //    // Save all fields (model binding already filled them)
        //    _context.Events.Add(newEvent);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event newEvent)
        {
            if (newEvent == null ||
                string.IsNullOrWhiteSpace(newEvent.Name) ||
                string.IsNullOrWhiteSpace(newEvent.Email) ||
                newEvent.Duration <= 0 ||
                newEvent.Jumpers <= 0)
            {
                return BadRequest("Invalid booking data.");
            }

            // Compute StartTime and EndTime
            var startDateTime = newEvent.Date.Date + newEvent.Time;
            newEvent.StartTime = startDateTime;
            newEvent.EndTime = startDateTime.AddHours(newEvent.Duration); // assuming Duration in hours; if minutes, use .AddMinutes

            // Initialize optional fields if missing
            newEvent.Socks = newEvent.Socks < 0 ? 0 : newEvent.Socks;
            newEvent.AddonsData ??= "{}";

            // Save to DB
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        }


        /// Get all booked events.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        /// Get event by ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null)
                return NotFound();

            return Ok(ev);
        }

        /// Update (edit) an existing event.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Event updatedEvent)
        {
            if (updatedEvent == null ||
                string.IsNullOrWhiteSpace(updatedEvent.Name) ||
                string.IsNullOrWhiteSpace(updatedEvent.Email) ||
                updatedEvent.Duration <= 0 ||
                updatedEvent.Jumpers <= 0)
            {
                return BadRequest("Invalid data.");
            }

            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
                return NotFound();

            // Update basic fields
            existingEvent.Name = updatedEvent.Name;
            existingEvent.Email = updatedEvent.Email;
            existingEvent.Date = updatedEvent.Date;
            existingEvent.Time = updatedEvent.Time;
            existingEvent.Duration = updatedEvent.Duration;
            existingEvent.Jumpers = updatedEvent.Jumpers;
            existingEvent.Socks = updatedEvent.Socks;

            // Update Add-ons
            existingEvent.EInvitation = updatedEvent.EInvitation;
            existingEvent.GameCoach = updatedEvent.GameCoach;
            existingEvent.WaterBottle = updatedEvent.WaterBottle;
            existingEvent.MelonaIC = updatedEvent.MelonaIC;

            existingEvent.TrampolineGames = updatedEvent.TrampolineGames;

            // Party Area
            existingEvent.PartyArea = updatedEvent.PartyArea;
            existingEvent.PartyGuest = updatedEvent.PartyGuest;
            existingEvent.PartyHours = updatedEvent.PartyHours;

            // Party Decorations
            existingEvent.PartyDecorationsEnabled = updatedEvent.PartyDecorationsEnabled;
            existingEvent.PartyDecorations = updatedEvent.PartyDecorations;
            existingEvent.FoodCart = updatedEvent.FoodCart;
            existingEvent.ElecFoodCart = updatedEvent.ElecFoodCart;

            // Party Equipment
            existingEvent.PartyEquipment = updatedEvent.PartyEquipment;
            existingEvent.PartyEquipCD = updatedEvent.PartyEquipCD;
            existingEvent.PartyEquipUtils = updatedEvent.PartyEquipUtils;

            // Keep AddonsData if used
            existingEvent.AddonsData = updatedEvent.AddonsData;

            // Recompute StartTime and EndTime
            var startDateTime = updatedEvent.Date.Date + updatedEvent.Time;
            existingEvent.StartTime = startDateTime;
            existingEvent.EndTime = startDateTime.AddHours(updatedEvent.Duration);

            await _context.SaveChangesAsync();

            return Ok(existingEvent);
        }

        /// Delete event by ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
                return NotFound();

            _context.Events.Remove(existingEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
