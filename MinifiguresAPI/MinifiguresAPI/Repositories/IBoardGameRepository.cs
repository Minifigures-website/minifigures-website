using MinifiguresAPI.Models;

namespace MinifiguresAPI.Repositories
{
    public interface IBoardGameRepository
    {
        Task<List<BoardGame>> GetBoardGames();
        Task<BoardGame>? GetSingleBoardGames(int id);
        Task CreateBoardGame(BoardGameCreateDto boardGame);
        Task<List<BoardGame>?> UpdateBoardGame(int id, BoardGameUpdateDto newData);
        Task<List<BoardGame>?> DeleteBoardGame(int id);
    }
}
