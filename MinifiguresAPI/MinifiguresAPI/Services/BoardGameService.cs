
using MinifiguresAPI.Models;
using MinifiguresAPI.Models.ModelsDto;
using MinifiguresAPI.Repositories.Interfaces;
using MinifiguresAPI.Services.Interfaces;
using MinifiguresAPI.Validators.Interfaces;

namespace MinifiguresAPI.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IBoardGameServiceValidator _boardGameServiceValidator;

        public BoardGameService(IBoardGameRepository boardGameRepository,
                                IBoardGameServiceValidator boardGameServiceValidator)
        {
            _boardGameRepository = boardGameRepository;
            _boardGameServiceValidator = boardGameServiceValidator;
        }

        public async Task<List<BoardGame>> GetBoardGames()
        {
            return await _boardGameRepository.GetBoardGames();
        }

        public async Task<BoardGame> GetSingleBoardGames(int id)
        {
            await _boardGameServiceValidator.ValidateGetSingle(id);
            return await _boardGameRepository.GetSingleBoardGames(id);
        }

        public async Task<BoardGame> CreateBoardGame(BoardGameCreateDto boardGame)
        {
            await _boardGameServiceValidator.ValidateCreate(boardGame);
            return await _boardGameRepository.CreateBoardGame(boardGame);
        }

        public async Task<List<BoardGame>> DeleteBoardGame(int id)
        {
            await _boardGameServiceValidator.ValidateDelete(id);
            return await _boardGameRepository.DeleteBoardGame(id);
        }

        public async Task<List<BoardGame>> UpdateBoardGame(int id, BoardGameUpdateDto newData)
        {
            await _boardGameServiceValidator.ValidateUpdate(id, newData);
            return await _boardGameRepository.UpdateBoardGame(id, newData);
        }
    }
}
