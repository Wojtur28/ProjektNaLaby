using System.Security.Claims;
using Projekt.Data;
using Projekt.DTOS.Opinion;

namespace Projekt.Services.OpinionService;

public class OpinionService : IOpinionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public OpinionService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    
    
    public async Task<ServiceResponse<GetGameDto>> AddOpinion(AddOpinionDto newOpinion)
    {
        var response = new ServiceResponse<GetGameDto>();
        try
        {
            var game = await _context.Games
                .FirstOrDefaultAsync(c => c.Id == newOpinion.GameId && 
                                          c.User!.Id == int.Parse(_httpContextAccessor.HttpContext!.User
                                              .FindFirstValue(ClaimTypes.NameIdentifier)!));

            if (game is null)
            {
                response.Success = false;
                response.Message = "Game not found.";
                return response;
            }

            var opinion = new Opinion
            {
                Text = newOpinion.Text,
                Rating = newOpinion.Rating,
                Game = game
            };
            
            _context.Opinions.Add(opinion);
            await _context.SaveChangesAsync();
            
            response.Data = _mapper.Map<GetGameDto>(game);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }
}