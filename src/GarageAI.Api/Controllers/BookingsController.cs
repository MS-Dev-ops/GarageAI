using GarageAI.Application.Bookings.Queries.GetBookings;
using Microsoft.AspNetCore.Mvc;

namespace GarageAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly GetBookingsQueryHandler _handler;

    public BookingsController(GetBookingsQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var bookings = await _handler.Handle(new GetBookingsQuery());

        return Ok(bookings);
    }
}