using GarageAI.Application.ServicePackages.DTOs;
using GarageAI.Application.ServicePackages.Interfaces;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class ServicePackageRepository : IServicePackageRepository
{
    private readonly GarageDbContext _context;

    public ServicePackageRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServicePackageDto>> GetServicePackagesAsync()
    {
        return await _context.ServicePackages
            .OrderBy(p => p.Name)
            .Select(p => new ServicePackageDto
            {
                Id = p.Id,
                Name = p.Name,
                Discount = p.Discount,
                IsActive = p.IsActive
            })
            .ToListAsync();
    }
}