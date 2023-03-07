using AutoMapper;
using MinifiguresAPI.Data;
using MinifiguresAPI.Models;

namespace MinifiguresAPI.Repositories
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BoardGameRepository(IMapper mapper,
                                   DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<BoardGame>> GetBoardGames()
        {
            return await _context.BoardGames.ToListAsync();
        }

        public async Task<BoardGame>? GetSingleBoardGames(int id)
        {
            var dbBoardGame = await _context.BoardGames.FindAsync(id);
            if (dbBoardGame == null)
                return null;

            return dbBoardGame;
        }

        public async Task<BoardGame>? CreateBoardGame(BoardGameCreateDto boardGame)
        {
            var dbBoardGame = _mapper.Map<BoardGame>(boardGame);

            _context.BoardGames.Add(dbBoardGame);
            await _context.SaveChangesAsync();
            return dbBoardGame;
        }

        public async Task<List<BoardGame>?> DeleteBoardGame(int id)
        {
            var dbBoardGame = await _context.BoardGames.FindAsync(id);
            if (dbBoardGame == null)
                return null;

            _context.BoardGames.Remove(dbBoardGame);
            await _context.SaveChangesAsync();

            return await _context.BoardGames.ToListAsync();
        }

        public async Task<List<BoardGame>?> UpdateBoardGame(int id, BoardGameUpdateDto newData)
        {
            var dbBoardGame = await _context.BoardGames.FindAsync(id);
            if (dbBoardGame == null)
                return null;

            _mapper.Map(newData, dbBoardGame);

            dbBoardGame.Title = newData.Title;
            dbBoardGame.Authors = newData.Authors;
            dbBoardGame.Description = newData.Description;
            dbBoardGame.AvgPlaytime = newData.AvgPlaytime;
            dbBoardGame.PhysicalMinis = newData.PhysicalMinis;

            await _context.SaveChangesAsync();

            return await _context.BoardGames.ToListAsync();
        }
    }
}
