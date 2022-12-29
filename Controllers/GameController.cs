using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet]
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
    
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> UpdateGame(UpdateGameDto updateGame)
    {
        var response = await _gameService.UpdateGame(updateGame);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetGameDto>>> DeleteGame(int id)
    {
        var response = await _gameService.DeleteGame(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}