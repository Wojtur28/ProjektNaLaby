using Projekt.DTOS.Opinion;
using Projekt.Migrations;

namespace Projekt;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Game, GetGameDto>();
        CreateMap<AddGameDto, Game>();
        CreateMap<Opinions, GetOpinionDto>();


    }
}
