using GarageAI.Application.Dashboard.Queries.GetDashboard;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly GetDashboardQueryHandler _handler;

    public DashboardController(GetDashboardQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var dashboard = await _handler.Handle(new GetDashboardQuery());

        return Ok(dashboard);
    }
}