using Microsoft.AspNetCore.Mvc;

namespace Projekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet("GetAll")]
    public async  Task<ActionResult<ServiceResponse<List<GetGameDto>>>> Get()
    {
        return Ok(await _gameService.GetAllGames());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetGameDto>>> GetSingle(int id)
    {
        return Ok(await _gameService.GetGameById(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> AddGame(AddGameDto newGame)
    {
        return Ok(await _gameService.AddGame(newGame));
    }

}