using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public UpdatesController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/Updates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Update>>> GetUpdates()
        {
          if (_context.Updates == null)
          {
              return NotFound();
          }
            return await _context.Updates.ToListAsync();
        }

        // GET: api/Updates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Update>> GetUpdate(int id)
        {
          if (_context.Updates == null)
          {
              return NotFound();
          }
            var update = await _context.Updates.FindAsync(id);

            if (update == null)
            {
                return NotFound();
            }

            return update;
        }

        // PUT: api/Updates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(int id, Update update)
        {
            if (id != update.UpdateId)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpdateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Updates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Update>> PostUpdate(Update update)
        {
          if (_context.Updates == null)
          {
              return Problem("Entity set 'SocialGoalContext.Updates'  is null.");
          }
            _context.Updates.Add(update);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUpdate", new { id = update.UpdateId }, update);
        }

        // DELETE: api/Updates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUpdate(int id)
        {
            if (_context.Updates == null)
            {
                return NotFound();
            }
            var update = await _context.Updates.FindAsync(id);
            if (update == null)
            {
                return NotFound();
            }

            _context.Updates.Remove(update);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UpdateExists(int id)
        {
            return (_context.Updates?.Any(e => e.UpdateId == id)).GetValueOrDefault();
        }
    }
}
