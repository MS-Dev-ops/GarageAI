using GarageAI.Application.Services.Queries.GetServices;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly GetServicesQueryHandler _handler;

    public ServicesController(GetServicesQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var services = await _handler.Handle(new GetServicesQuery());

        return Ok(services);
    }
}