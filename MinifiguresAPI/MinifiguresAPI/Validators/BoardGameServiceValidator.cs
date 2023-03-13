using MinifiguresAPI.Common.Data;
using MinifiguresAPI.Models.ModelsDto;
using MinifiguresAPI.Repositories.Interfaces;
using MinifiguresAPI.Validators.Interfaces;

namespace MinifiguresAPI.Validators
{
    public class BoardGameServiceValidator : IBoardGameServiceValidator
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly DataContext _context;

        public BoardGameServiceValidator(IBoardGameRepository boardGameRepository,
                                         DataContext context)
        {
            _boardGameRepository = boardGameRepository;
            _context = context;
        }

        public async Task ValidateAdd(BoardGameCreateDto boardGameDto)
        {
            if (boardGameDto == null)
            {
                throw new Exception(message: "Provided object is null");
            }
            bool exists = await IsNameExists(boardGameDto.Title);
            if (exists)
            {
                throw new Exception(message: "Duplicated Board Game Name");
            }
        }

        public async Task ValidateDelete(int id)
        {
            await IsIdExists(id);
        }

        public async Task ValidateUpdate(int id, BoardGameUpdateDto newData)
        {
            await IsIdExists(id);
            if (newData == null)
            {
                throw new Exception(message: "Provided object is null");
            }
            bool exists = await IsNameExists(newData.Title);
            if (exists)
            {
                throw new Exception(message: "Duplicated Board Game Name");
            }
        }

        public async Task ValidateGetById(int id)
        {
            await IsIdExists(id);
        }

        private async Task<bool> IsNameExists(string title)
        {
            return await _context.BoardGames
                .AnyAsync(x => x.Title == title);
        }

        private async Task IsIdExists(int id)
        {
            var isExists = await _boardGameRepository.GetBoardGameById(id);
            if (isExists == null)
            {
                throw new Exception(message: $"Board Game with Id = {id} doesn't exists.");
            }
        }
    }
}
