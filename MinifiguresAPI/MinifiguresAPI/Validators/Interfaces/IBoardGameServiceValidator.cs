using MinifiguresAPI.Models.ModelsDto;

namespace MinifiguresAPI.Validators.Interfaces
{
    public interface IBoardGameServiceValidator
    {
        public Task ValidateAdd(BoardGameCreateDto boardGameDto);
        public Task ValidateUpdate(int id, BoardGameUpdateDto newData);
        public Task ValidateDelete(int id);
        public Task ValidateGetById(int id);
    }
}
