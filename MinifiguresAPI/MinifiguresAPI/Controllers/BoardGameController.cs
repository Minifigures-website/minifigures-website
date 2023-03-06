using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinifiguresAPI.Models;
using MinifiguresAPI.Services;

namespace MinifiguresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IMapper _mapper;

        public BoardGameController(IBoardGameService boardGameService,
            IMapper mapper)
        {
            _boardGameService = boardGameService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoardGame>>> GetBoardGames()
        {
            return Ok(await _boardGameService.GetBoardGames());
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
        public async Task<ActionResult> CreateBoardGame(BoardGameCreateDto boardGame)
        {
            await _boardGameService.CreateBoardGame(boardGame);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<BoardGame>>> UpdateBoardGame(int id, BoardGameUpdateDto newData)
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
