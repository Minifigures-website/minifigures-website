using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinifiguresAPI.Data;

namespace MinifiguresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly DataContext _context;

        public BoardGameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoardGame>>> GetBoardGames()
        {
            return Ok(await _context.BoardGame.ToListAsync());
        }
    }
}
