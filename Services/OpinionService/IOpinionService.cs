using Projekt.DTOS.Opinion;

namespace Projekt.Services.OpinionService;

public interface IOpinionService
{
    Task<ServiceResponse<GetGameDto>> AddOpinion(AddOpinionDto newOpinion);
}