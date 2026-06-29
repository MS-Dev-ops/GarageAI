using GarageAI.Application.Bookings.Interfaces;
using GarageAI.Application.Bookings.Queries.GetBookings;
using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly GarageDbContext _context;

    public BookingRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookingDto>> GetBookingsAsync()
    {
        return await (
            from booking in _context.Bookings

            join customer in _context.Customers
                on booking.CustomerId equals customer.Id

            join vehicle in _context.Vehicles
                on booking.VehicleId equals vehicle.Id

            join package in _context.ServicePackages
                on booking.ServicePackageId equals package.Id
                into packages

            from package in packages.DefaultIfEmpty()

            orderby booking.BookingDate

            select new BookingDto
            {
                Id = booking.Id,

                CustomerName = customer.FirstName + " " + customer.LastName,

                RegistrationNumber = vehicle.RegistrationNumber,

                Vehicle = vehicle.Make + " " + vehicle.Model,

                BookingDate = booking.BookingDate,

                PackageName = package != null ? package.Name : "",

                Status = booking.Status.ToString()
            }

        ).ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        return await _context.Bookings.FindAsync(id);
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var booking = await _context.Bookings.FindAsync(id);

        if (booking is null)
            return;

        _context.Bookings.Remove(booking);

        await _context.SaveChangesAsync();
    }
}