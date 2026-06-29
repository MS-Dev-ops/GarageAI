using GarageAI.Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var customers = await _customerService.GetAllAsync();

        return Ok(customers);
    }
}