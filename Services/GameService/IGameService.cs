

namespace Projekt.Services.GameService;

public interface IGameService
{
    Task<ServiceResponse<List<GetGameDto>>> GetAllGames();
    Task<ServiceResponse<GetGameDto>> GetGameById(int id);
    Task<ServiceResponse<List<GetGameDto>>> AddGame(AddGameDto newGame);
}