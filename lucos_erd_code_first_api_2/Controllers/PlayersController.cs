using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lucos_erd_code_first_api_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DataContext _context;

        public PlayersController(DataContext context)
        {
            _context = context;
        }

        // GET /api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET /api/Players/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(Guid id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }


        // POST /api/Players
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, player);
        }

        // PUT /api/Players/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(Guid id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // DELETE /api/Players/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(Guid id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}