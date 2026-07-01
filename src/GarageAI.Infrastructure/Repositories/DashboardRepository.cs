using GarageAI.Application.Dashboard.DTOs;
using GarageAI.Application.Interfaces;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly GarageDbContext _context;

    public DashboardRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        return new DashboardDto
        {
            Customers = await _context.Customers.CountAsync(),

            Vehicles = await _context.Vehicles.CountAsync(),

            BookingsToday = await _context.Bookings
                .CountAsync(b => b.BookingDate.Date == DateTime.Today),

            AvailableMechanics = await _context.Mechanics
                .CountAsync(m => m.IsAvailable),

            ActiveServicePackages = await _context.ServicePackages
                .CountAsync(p => p.IsActive)
        };
    }
}