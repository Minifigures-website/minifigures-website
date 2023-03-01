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
            var boardGames = await _context.BoardGames.ToListAsync();
            return boardGames;
        }
        public async Task<BoardGame>? GetSingleBoardGames(int id)
        {
            var dbBoardGame = await _context.BoardGames.FindAsync(id);
            if (dbBoardGame == null)
                return null;

            return dbBoardGame;
        }
        public async Task<List<BoardGame>> AddBoardGame(BoardGame boardGame)
        {
            _context.BoardGames.Add(boardGame);
            await _context.SaveChangesAsync();

            return await _context.BoardGames.ToListAsync();
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


        public async Task<List<BoardGame>?> UpdateBoardGame(int id, BoardGame newData)
        {
            var dbBoardGame = await _context.BoardGames.FindAsync(id);
            if (dbBoardGame == null)
                return null;

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
