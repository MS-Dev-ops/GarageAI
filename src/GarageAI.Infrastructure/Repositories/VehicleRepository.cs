using GarageAI.Application.Interfaces;
using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly GarageDbContext _context;

    public VehicleRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles
            .OrderBy(v => v.Make)
            .ThenBy(v => v.Model)
            .ToListAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle is null)
            return;

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
    }
}