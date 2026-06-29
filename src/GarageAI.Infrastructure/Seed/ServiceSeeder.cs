using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class ServiceSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.Services.AnyAsync())
            return;

        var services = new List<Service>
        {
            new("MOT", 54.85m, 60),
            new("Interim Service", 149.99m, 120),
            new("Full Service", 249.99m, 180),
            new("Major Service", 349.99m, 240),
            new("Oil Change", 79.99m, 45),
            new("Brake Inspection", 49.99m, 30),
            new("Air Conditioning Service", 99.99m, 60),
            new("Wheel Alignment", 69.99m, 45)
        };

        context.Services.AddRange(services);

        await context.SaveChangesAsync();
    }
}