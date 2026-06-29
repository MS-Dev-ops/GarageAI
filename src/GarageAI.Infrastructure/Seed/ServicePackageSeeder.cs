using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class ServicePackageSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.ServicePackages.AnyAsync())
            return;

        var packages = new List<ServicePackage>
        {
            new("MOT + Full Service", 10),
            new("Major Service + MOT", 15),
            new("Winter Health Check", 20)
        };

        context.ServicePackages.AddRange(packages);

        await context.SaveChangesAsync();
    }
}