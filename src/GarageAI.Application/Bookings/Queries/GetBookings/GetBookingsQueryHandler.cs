using GarageAI.Application.Bookings.Interfaces;

namespace GarageAI.Application.Bookings.Queries.GetBookings;

public class GetBookingsQueryHandler
{
    private readonly IBookingRepository _bookingRepository;

    public GetBookingsQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<List<BookingDto>> Handle(GetBookingsQuery query)
    {
        return await _bookingRepository.GetBookingsAsync();
    }
}