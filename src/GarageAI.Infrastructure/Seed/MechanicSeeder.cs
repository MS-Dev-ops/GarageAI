using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class MechanicSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.Mechanics.AnyAsync())
            return;

        var mechanics = new List<Mechanic>
        {
            new("Mike", "Wilson"),
            new("James", "Cooper"),
            new("Peter", "White"),
            new("Chris", "Evans")
        };

        context.Mechanics.AddRange(mechanics);

        await context.SaveChangesAsync();
    }
}