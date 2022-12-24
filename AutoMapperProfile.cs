namespace Projekt;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Game, GetGameDto>();
        CreateMap<AddGameDto, Game>();
    }
}
