﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lucos_erd_code_first_api_2.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningsController : ControllerBase
    {
        private readonly DataContext _context;

        public OpeningsController(DataContext context)
        {
            _context = context;
        }

        // GET /api/Openings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opening>>> GetOpenings()
        {
            return await _context.Openings.ToListAsync();
        }

        // GET /api/Openings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Opening>> GetOpening(string id)
        {
            var opening = await _context.Openings.FindAsync(id);

            if (opening == null)
            {
                return NotFound();
            }

            return opening;
        }

        // POST /api/Openings
        [HttpPost]
        public async Task<ActionResult<Opening>> PostOpening(Opening opening)
        {
            _context.Openings.Add(opening);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOpening), new { id = opening.OpeningCode }, opening);
        }

        // PUT /api/Openings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpening(string id, Opening opening)
        {
            if (id != opening.OpeningCode)
            {
                return BadRequest();
            }

            _context.Entry(opening).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpeningExists(id))
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

        // DELETE /api/Openings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpening(string id)
        {
            var opening = await _context.Openings.FindAsync(id);
            if (opening == null)
            {
                return NotFound();
            }

            _context.Openings.Remove(opening);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpeningExists(string id)
        {
            return _context.Openings.Any(e => e.OpeningCode == id);
        }
    }
}