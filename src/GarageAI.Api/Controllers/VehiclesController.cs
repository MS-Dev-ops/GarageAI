using GarageAI.Application.Customers;
using GarageAI.Application.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly VehicleService _vehiclesService;

    public VehiclesController(VehicleService vehiclesService)
    {
        _vehiclesService = vehiclesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var vehicles = await _vehiclesService.GetAllAsync();

        return Ok(vehicles);
    }
}