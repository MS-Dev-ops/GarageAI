using GarageAI.Application.Services.DTOs;
using GarageAI.Application.Services.Interfaces;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly GarageDbContext _context;

    public ServiceRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServiceDto>> GetServicesAsync()
    {
        return await _context.Services
            .OrderBy(s => s.Name)
            .Select(s => new ServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                DurationMinutes = s.DurationMinutes
            })
            .ToListAsync();
    }
}