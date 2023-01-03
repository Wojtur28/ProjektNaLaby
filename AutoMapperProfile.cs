using Projekt.DTOS.Opinion;

namespace Projekt;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Game, GetGameDto>();
        CreateMap<AddGameDto, Game>();
        CreateMap<UpdateGameDto, Game>();
        CreateMap<Opinion, GetOpinionDto>();
        CreateMap<AddOpinionDto, Opinion>();

    }
    
}
