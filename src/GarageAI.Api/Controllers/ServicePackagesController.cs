using GarageAI.Application.ServicePackages.Queries.GetServicePackages;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicePackagesController : ControllerBase
{
    private readonly GetServicePackagesQueryHandler _handler;

    public ServicePackagesController(GetServicePackagesQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var packages = await _handler.Handle(new GetServicePackagesQuery());

        return Ok(packages);
    }
}