using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinifiguresAPI.Data;
using MinifiguresAPI.Models;

namespace MinifiguresAPI.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly DataContext _context;

        public BoardGameService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BoardGame>> GetBoardGames()
        {
            return await _context.BoardGame.ToListAsync();
        }
        public async Task<List<BoardGame>> CreateBoardGame(BoardGame boardGame)
        {
            _context.BoardGame.Add(boardGame);
            await _context.SaveChangesAsync();

            return await _context.BoardGame.ToListAsync();
        }

        public async Task<List<BoardGame>> DeleteBoardGame(int id)
        {
            var dbBoardGame = await _context.BoardGame.FindAsync(id);
            if (dbBoardGame == null)
                return BadRequest("BoardGame not found.");

            _context.BoardGame.Remove(dbBoardGame);
            await _context.SaveChangesAsync();

            return await _context.BoardGame.ToListAsync();
        }


        public async Task<List<BoardGame>> UpdateBoardGame(BoardGame boardGame)
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

            return await _context.BoardGame.ToListAsync();
        }
    }
}
