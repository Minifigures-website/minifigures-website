namespace MinifiguresAPI.Services
{
    public interface IBoardGameService
    {
        Task<List<BoardGame>> GetBoardGames();
        Task<BoardGame>? GetSingleBoardGames(int id);
        Task<List<BoardGame>> AddBoardGame(BoardGame boardGame);
        Task<List<BoardGame>?> UpdateBoardGame(int id, BoardGame newData);
        Task<List<BoardGame>?> DeleteBoardGame(int id);
    }
}
