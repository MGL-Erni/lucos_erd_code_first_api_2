using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lucos_erd_code_first_api_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _context;

        public GamesController(DataContext context)
        {
            _context = context;
        }

        // GET /api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games
                .Include(g => g.PlayerW)
                .Include(g => g.PlayerB)
                .Include(g => g.OpeningPlayed)
                .ToListAsync();
        }

        // GET /api/Games/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games
                .Include(g => g.PlayerW)
                .Include(g => g.PlayerB)
                .Include(g => g.OpeningPlayed)
                .FirstOrDefaultAsync(g => g.GameNumber == id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // POST /api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.GameNumber }, game);
        }

        // PUT /api/Games/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameNumber)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // DELETE /api/Games/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameNumber == id);
        }
    }
}