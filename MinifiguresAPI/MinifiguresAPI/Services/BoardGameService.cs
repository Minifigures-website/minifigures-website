
using MinifiguresAPI.Models;
using MinifiguresAPI.Repositories;

namespace MinifiguresAPI.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;

        public BoardGameService(IBoardGameRepository boardGameRepository)
        {   
            _boardGameRepository = boardGameRepository;
        }
        public async Task<List<BoardGame>> GetBoardGames()
        {
            return await _boardGameRepository.GetBoardGames();
        }
        public async Task<BoardGame>? GetSingleBoardGames(int id)
        {
            return await _boardGameRepository.GetSingleBoardGames(id);
        }
        public async Task CreateBoardGame(BoardGameCreateDto boardGame)
        {
            await _boardGameRepository.CreateBoardGame(boardGame);
        }

        public async Task<List<BoardGame>?> DeleteBoardGame(int id)
        {
            return await _boardGameRepository.DeleteBoardGame(id);
        }

        public async Task<List<BoardGame>?> UpdateBoardGame(int id, BoardGameUpdateDto newData)
        {
            return await _boardGameRepository.UpdateBoardGame(id, newData);
        }

    }
}
