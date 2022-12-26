global using AutoMapper;
using Projekt.Data;

namespace Projekt.Services.GameService;

public class GameService : IGameService
{

    private readonly  DataContext _context;
    private readonly IMapper _mapper;

    public GameService(IMapper mapper, DataContext context)
    {
        _context = context;
        _mapper = mapper;
    }
    

    public async Task<ServiceResponse<List<GetGameDto>>> GetAllGames()
    {
        var serviceResponse = new ServiceResponse<List<GetGameDto>>();
        var dbGames = await _context.Games.ToListAsync();
        serviceResponse.Data = dbGames.Select(c => _mapper.Map<GetGameDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetGameDto>> GetGameById(int id)
    {
        var serviceResponse = new ServiceResponse<GetGameDto>();
        var dbGame = await _context.Games.FirstOrDefaultAsync(c => c.Id == id);
        serviceResponse.Data = _mapper.Map<GetGameDto>(dbGame);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetGameDto>>> AddGame(AddGameDto newGame)
    {
        var serviceResponse = new ServiceResponse<List<GetGameDto>>();
        var game = _mapper.Map<Game>(newGame);

       
        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        serviceResponse.Data =
            await _context.Games.Select(c => _mapper.Map<GetGameDto>(c)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetGameDto>> UpdateGame(UpdateGameDto updateGame)
    {
        var serviceResponse = new ServiceResponse<GetGameDto>();
        
        try
        {
            
            var game = 
                await _context.Games.FirstOrDefaultAsync(c => c.Id == updateGame.Id);
            if(game is null)
                throw new Exception($"Game with id {updateGame.Id} not found.");
            
            game.Name = updateGame.Name;
            game.ReleaseDate = updateGame.ReleaseDate;
            game.Category = updateGame.Category;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetGameDto>(game);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
            
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetGameDto>>> DeleteGame(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetGameDto>>();
        
        try
        {
            
            var game = await _context.Games.FirstOrDefaultAsync(c => c.Id == id);
            if(game is null)
                throw new Exception($"Game with id {id} not found.");
            
            _context.Games.Remove(game);

            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Games.Select(c => _mapper.Map<GetGameDto>(c)).ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
            
        }
        return serviceResponse;
    }
}