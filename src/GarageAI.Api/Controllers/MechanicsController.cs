using GarageAI.Application.Mechanics.Queries.GetMechanics;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MechanicsController : ControllerBase
{
    private readonly GetMechanicsQueryHandler _handler;

    public MechanicsController(GetMechanicsQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var mechanics = await _handler.Handle(new GetMechanicsQuery());

        return Ok(mechanics);
    }
}