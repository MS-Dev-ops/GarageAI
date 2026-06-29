using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class CustomerSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.Customers.AnyAsync())
            return;

        var customers = new List<Customer>
        {
            new("John","Smith","07700111221","john.smith@email.com"),
            new("Sarah","Jones","07700111222","sarah.jones@email.com"),
            new("David","Brown","07700111223","david.brown@email.com"),
            new("Emma","Wilson","07700111224","emma.wilson@email.com"),
            new("James","Taylor","07700111225","james.taylor@email.com"),
            new("Olivia","Johnson","07700111226","olivia.johnson@email.com"),
            new("Michael","Green","07700111227","michael.green@email.com"),
            new("Daniel","Thomas","07700111228","daniel.thomas@email.com"),
            new("Chloe","Davies","07700111229","chloe.davies@email.com"),
            new("Sophie","Evans","07700111230","sophie.evans@email.com")
        };

        context.Customers.AddRange(customers);

        await context.SaveChangesAsync();
    }
}