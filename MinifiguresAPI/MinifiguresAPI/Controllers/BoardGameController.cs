using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinifiguresAPI.Models;
using MinifiguresAPI.Models.ModelsDto;
using MinifiguresAPI.Services.Interfaces;

namespace MinifiguresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IMapper _mapper;
        private readonly IValidator<BoardGameCreateDto> _boardGameCreateValidator;
        private readonly IValidator<BoardGameUpdateDto> _boardGameUpdateValidator;

        public BoardGameController(IBoardGameService boardGameService,
                                   IMapper mapper,
                                   IValidator<BoardGameUpdateDto> boardGameUpdateValidator,
                                   IValidator<BoardGameCreateDto> boardGameCreateValidator)
        {
            _boardGameService = boardGameService;
            _mapper = mapper;
            _boardGameUpdateValidator = boardGameUpdateValidator;
            _boardGameCreateValidator = boardGameCreateValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoardGame>?>> GetAllBoardGames()
        {
            return Ok(await _boardGameService.GetAllBoardGames());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardGame>> GetBoardGameById(int id)
        {
            var result = await _boardGameService.GetBoardGameById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BoardGame>> AddBoardGame(BoardGameCreateDto boardGame)
        {
            var validationResult = _boardGameCreateValidator.Validate(boardGame);
            if (validationResult.IsValid)
            {
                var result = await _boardGameService.AddBoardGame(boardGame);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<BoardGame>>> UpdateBoardGame(int id, BoardGameUpdateDto newData)
        {
            var validationResult = _boardGameUpdateValidator.Validate(newData);
            if (validationResult.IsValid)
            {
                var result = await _boardGameService.UpdateBoardGame(id, newData);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BoardGame>>> DeleteBoardGame(int id)
        {
            var result = await _boardGameService.DeleteBoardGame(id);
            return Ok(result);
        }
    }
}
