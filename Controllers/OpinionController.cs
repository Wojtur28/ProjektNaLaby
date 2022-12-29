using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.DTOS.Opinion;
using Projekt.Services.OpinionService;

namespace Projekt.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OpinionController : ControllerBase
{
    private readonly IOpinionService _opinionService;
    public OpinionController(IOpinionService opinionService)
    {
        _opinionService = opinionService;
    }
    
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetGameDto>>> AddOpinion(AddOpinionDto newOpinion)
    {
        return Ok(await _opinionService.AddOpinion(newOpinion));
    }
    
}