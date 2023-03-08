using MinifiguresAPI.Models.ModelsDto;

namespace MinifiguresAPI.Validators.Interfaces
{
    public interface IBoardGameServiceValidator
    {
        public Task ValidateCreate(BoardGameCreateDto boardGameDto);
        public Task ValidateUpdate(int id, BoardGameUpdateDto newData);
        public Task ValidateDelete(int id);
        public Task ValidateGetSingle(int id);
    }
}
