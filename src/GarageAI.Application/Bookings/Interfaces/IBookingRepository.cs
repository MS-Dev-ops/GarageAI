using GarageAI.Application.Bookings.Queries.GetBookings;
using GarageAI.Domain.Entities;

namespace GarageAI.Application.Bookings.Interfaces;

public interface IBookingRepository
{
    Task<List<BookingDto>> GetBookingsAsync();

    Task<Booking?> GetByIdAsync(Guid id);

    Task AddAsync(Booking booking);

    Task UpdateAsync(Booking booking);

    Task DeleteAsync(Guid id);
}