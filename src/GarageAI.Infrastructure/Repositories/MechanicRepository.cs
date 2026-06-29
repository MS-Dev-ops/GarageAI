using GarageAI.Application.Mechanics.DTOs;
using GarageAI.Application.Mechanics.Interfaces;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class MechanicRepository : IMechanicRepository
{
    private readonly GarageDbContext _context;

    public MechanicRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<MechanicDto>> GetMechanicsAsync()
    {
        return await _context.Mechanics
            .OrderBy(m => m.FirstName)
            .Select(m => new MechanicDto
            {
                Id = m.Id,
                FullName = $"{m.FirstName} {m.LastName}",
                Status = m.IsAvailable ? "Available" : "Busy"
            })
            .ToListAsync();
    }
}