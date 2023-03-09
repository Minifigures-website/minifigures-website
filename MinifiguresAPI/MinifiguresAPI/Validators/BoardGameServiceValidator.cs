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

        public async Task ValidateCreate(BoardGameCreateDto boardGameDto)
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
            if (newData == null)
            {
                throw new Exception(message: "Provided object is null");
            }
            await IsIdExists(id);
        }

        public async Task ValidateGetSingle(int id)
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
            var isExists = await _boardGameRepository.GetSingleBoardGames(id);
            if (isExists == null)
            {
                throw new Exception(message: $"Board Game with Id = {id} doesn't exists.");
            }
        }
    }
}
