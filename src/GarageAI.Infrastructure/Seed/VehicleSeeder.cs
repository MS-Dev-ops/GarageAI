using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class VehicleSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.Vehicles.AnyAsync())
            return;

        var customers = await context.Customers.ToListAsync();

        var john = customers.Single(c => c.Email == "john.smith@email.com");
        var sarah = customers.Single(c => c.Email == "sarah.jones@email.com");
        var david = customers.Single(c => c.Email == "david.brown@email.com");
        var emma = customers.Single(c => c.Email == "emma.wilson@email.com");
        var james = customers.Single(c => c.Email == "james.taylor@email.com");
        var olivia = customers.Single(c => c.Email == "olivia.johnson@email.com");
        var michael = customers.Single(c => c.Email == "michael.green@email.com");
        var daniel = customers.Single(c => c.Email == "daniel.thomas@email.com");
        var chloe = customers.Single(c => c.Email == "chloe.davies@email.com");
        var sophie = customers.Single(c => c.Email == "sophie.evans@email.com");

        var vehicles = new List<Vehicle>
        {
            // John
            new(john.Id, "AB12 CDE", "BMW", "320d", 2021, 45210),
            new(john.Id, "YX21 KLM", "Mini", "Cooper", 2020, 38120),

            // Sarah
            new(sarah.Id, "XY21 ZZZ", "Audi", "A4", 2022, 22100),

            // David
            new(david.Id, "KP19 XYZ", "Ford", "Focus", 2019, 61250),

            // Emma
            new(emma.Id, "LM22 AAA", "Volkswagen", "Golf", 2022, 15800),

            // James
            new(james.Id, "BN70 QWE", "Mercedes", "C220", 2020, 49200),

            // Olivia
            new(olivia.Id, "EV24 CAR", "Tesla", "Model 3", 2024, 5200),

            // Michael
            new(michael.Id, "GH18 RTY", "Toyota", "Yaris", 2018, 70300),

            // Daniel
            new(daniel.Id, "JK23 UIO", "Nissan", "Qashqai", 2023, 9800),

            // Chloe
            new(chloe.Id, "MN17 PAS", "Honda", "Civic", 2017, 84500),

            // Sophie
            new(sophie.Id, "TR21 VBN", "Kia", "Sportage", 2021, 32100),
            new(sophie.Id, "WX19 HJK", "Hyundai", "i20", 2019, 43100)
        };

        context.Vehicles.AddRange(vehicles);

        await context.SaveChangesAsync();
    }
}