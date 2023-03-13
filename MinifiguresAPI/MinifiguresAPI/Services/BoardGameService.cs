
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

        public async Task<List<BoardGame>> GetAllBoardGames()
        {
            return await _boardGameRepository.GetAllBoardGames();
        }

        public async Task<BoardGame> GetBoardGameById(int id)
        {
            await _boardGameServiceValidator.ValidateGetById(id);
            return await _boardGameRepository.GetBoardGameById(id);
        }

        public async Task<BoardGame> AddBoardGame(BoardGameCreateDto boardGame)
        {
            await _boardGameServiceValidator.ValidateAdd(boardGame);
            return await _boardGameRepository.AddBoardGame(boardGame);
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
