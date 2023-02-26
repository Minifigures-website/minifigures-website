using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinifiguresAPI.Data;
using MinifiguresAPI.Models;

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
        [HttpPost]
        public async Task<ActionResult<List<BoardGame>>> CreateBoardGame(BoardGame boardGame)
        {
            _context.BoardGame.Add(boardGame);
            await _context.SaveChangesAsync();

            return Ok(await _context.BoardGame.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<BoardGame>>> UpdateBoardGame(BoardGame boardGame)
        {
            var dbBoardGame = await _context.BoardGame.FindAsync(boardGame.Id);
            if (dbBoardGame == null)
                return BadRequest("BoardGame not found.");

            dbBoardGame.Title = boardGame.Title;
            dbBoardGame.Authors = boardGame.Authors;
            dbBoardGame.Description = boardGame.Description;
            dbBoardGame.AvgPlaytime = boardGame.AvgPlaytime;
            dbBoardGame.PhysicalMinis = boardGame.PhysicalMinis;

            await _context.SaveChangesAsync();

            return Ok(await _context.BoardGame.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BoardGame>>> DeleteBoardGame(int id)
        {
            var dbBoardGame = await _context.BoardGame.FindAsync(id);
            if (dbBoardGame == null)
                return BadRequest("BoardGame not found.");

            _context.BoardGame.Remove(dbBoardGame);
            await _context.SaveChangesAsync();

            return Ok(await _context.BoardGame.ToListAsync());
        }
    }
}
