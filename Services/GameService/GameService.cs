global using AutoMapper;

namespace Projekt.Services.GameService;

public class GameService : IGameService
{
    private static List<Game> games = new List<Game>
    {
        new Game(),
        new Game { Id = 1, Name = "GTA V" }
    };

    private readonly IMapper _mapper;

    public GameService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<ServiceResponse<List<GetGameDto>>> GetAllGames()
    {
        var serviceResponse = new ServiceResponse<List<GetGameDto>>();
        serviceResponse.Data = games.Select(c => _mapper.Map<GetGameDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetGameDto>> GetGameById(int id)
    {
        var serviceResponse = new ServiceResponse<GetGameDto>();
        
        var game = games.FirstOrDefault(g => g.Id == id);
        serviceResponse.Data = _mapper.Map<GetGameDto>(game);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetGameDto>>> AddGame(AddGameDto newGame)
    {
        var serviceResponse = new ServiceResponse<List<GetGameDto>>();
        var game = _mapper.Map<Game>(newGame);
        game.Id = games.Max(c => c.Id) + 1;
        games.Add(game);
        serviceResponse.Data = games.Select(c => _mapper.Map<GetGameDto>(c)).ToList();
        return serviceResponse;
    }
}