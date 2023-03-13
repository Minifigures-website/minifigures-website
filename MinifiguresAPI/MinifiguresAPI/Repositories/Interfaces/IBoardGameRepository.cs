using MinifiguresAPI.Models;
using MinifiguresAPI.Models.ModelsDto;

namespace MinifiguresAPI.Repositories.Interfaces
{
    public interface IBoardGameRepository
    {
        Task<List<BoardGame>> GetAllBoardGames();
        Task<BoardGame> GetBoardGameById(int id);
        Task<BoardGame> AddBoardGame(BoardGameCreateDto boardGame);
        Task<List<BoardGame>> UpdateBoardGame(int id, BoardGameUpdateDto newData);
        Task<List<BoardGame>> DeleteBoardGame(int id);
    }
}
