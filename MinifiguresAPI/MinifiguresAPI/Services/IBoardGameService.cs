using MinifiguresAPI.Models;

namespace MinifiguresAPI.Services
{
    public interface IBoardGameService
    {
        public Task<List<BoardGame>> GetBoardGames();
        public Task<List<BoardGame>> CreateBoardGame(BoardGame boardGame);
        public Task<List<BoardGame>> UpdateBoardGame(BoardGame boardGame);
        public Task<List<BoardGame>> DeleteBoardGame(int id);
    }
}
