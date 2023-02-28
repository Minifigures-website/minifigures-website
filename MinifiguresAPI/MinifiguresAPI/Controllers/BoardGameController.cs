namespace MinifiguresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameService _boardGameService;

        public BoardGameController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoardGame>>> GetBoardGames()
        {
            return await _boardGameService.GetBoardGames();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardGame>> GetSingleBoardGames(int id)
        {
            var result = await _boardGameService.GetSingleBoardGames(id);
            if (result is null)
                return NotFound("BoardGame not found.");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BoardGame>>> AddBoardGame(BoardGame boardGame)
        {
            var result = await _boardGameService.AddBoardGame(boardGame);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<BoardGame>>> UpdateBoardGame(int id, BoardGame newData)
        {
            var result = await _boardGameService.UpdateBoardGame(id, newData);
            if (result is null) 
                return NotFound("BoardGame not found.");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BoardGame>>> DeleteBoardGame(int id)
        {
            var result = await _boardGameService.DeleteBoardGame(id);
            if (result is null) 
                return NotFound("BoardGame not found.");
            return Ok(result);
        }
    }
}
