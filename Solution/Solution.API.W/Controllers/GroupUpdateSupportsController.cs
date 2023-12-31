﻿using System;
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
    public class GroupUpdateSupportsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupUpdateSupportsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupUpdateSupports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupUpdateSupport>>> GetGroupUpdateSupports()
        {
          if (_context.GroupUpdateSupports == null)
          {
              return NotFound();
          }
            return await _context.GroupUpdateSupports.ToListAsync();
        }

        // GET: api/GroupUpdateSupports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupUpdateSupport>> GetGroupUpdateSupport(int id)
        {
          if (_context.GroupUpdateSupports == null)
          {
              return NotFound();
          }
            var groupUpdateSupport = await _context.GroupUpdateSupports.FindAsync(id);

            if (groupUpdateSupport == null)
            {
                return NotFound();
            }

            return groupUpdateSupport;
        }

        // PUT: api/GroupUpdateSupports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdateSupport(int id, GroupUpdateSupport groupUpdateSupport)
        {
            if (id != groupUpdateSupport.GroupUpdateSupportId)
            {
                return BadRequest();
            }

            _context.Entry(groupUpdateSupport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupUpdateSupportExists(id))
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

        // POST: api/GroupUpdateSupports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupUpdateSupport>> PostGroupUpdateSupport(GroupUpdateSupport groupUpdateSupport)
        {
          if (_context.GroupUpdateSupports == null)
          {
              return Problem("Entity set 'SocialGoalContext.GroupUpdateSupports'  is null.");
          }
            _context.GroupUpdateSupports.Add(groupUpdateSupport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupUpdateSupport", new { id = groupUpdateSupport.GroupUpdateSupportId }, groupUpdateSupport);
        }

        // DELETE: api/GroupUpdateSupports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupUpdateSupport(int id)
        {
            if (_context.GroupUpdateSupports == null)
            {
                return NotFound();
            }
            var groupUpdateSupport = await _context.GroupUpdateSupports.FindAsync(id);
            if (groupUpdateSupport == null)
            {
                return NotFound();
            }

            _context.GroupUpdateSupports.Remove(groupUpdateSupport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupUpdateSupportExists(int id)
        {
            return (_context.GroupUpdateSupports?.Any(e => e.GroupUpdateSupportId == id)).GetValueOrDefault();
        }
    }
}
