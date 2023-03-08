using MinifiguresAPI.Models;
using MinifiguresAPI.Models.ModelsDto;

namespace MinifiguresAPI.Repositories.Interfaces
{
    public interface IBoardGameRepository
    {
        Task<List<BoardGame>> GetBoardGames();
        Task<BoardGame>? GetSingleBoardGames(int id);
        Task<BoardGame>? CreateBoardGame(BoardGameCreateDto boardGame);
        Task<List<BoardGame>?> UpdateBoardGame(int id, BoardGameUpdateDto newData);
        Task<List<BoardGame>?> DeleteBoardGame(int id);
    }
}
