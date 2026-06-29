using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class BookingSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.Bookings.AnyAsync())
            return;

        var customers = await context.Customers.ToListAsync();
        var vehicles = await context.Vehicles.ToListAsync();
        var packages = await context.ServicePackages.ToListAsync();

        var bookings = new List<Booking>
        {
            new(customers[0].Id, vehicles[0].Id, DateTime.Today.AddDays(-30), packages[0].Id),
            new(customers[1].Id, vehicles[2].Id, DateTime.Today.AddDays(-20)),
            new(customers[2].Id, vehicles[3].Id, DateTime.Today.AddDays(-10), packages[1].Id),
            new(customers[3].Id, vehicles[4].Id, DateTime.Today.AddDays(-5)),
            new(customers[4].Id, vehicles[5].Id, DateTime.Today.AddDays(2)),
            new(customers[5].Id, vehicles[6].Id, DateTime.Today.AddDays(4)),
            new(customers[6].Id, vehicles[7].Id, DateTime.Today.AddDays(7), packages[2].Id),
            new(customers[7].Id, vehicles[8].Id, DateTime.Today.AddDays(9)),
            new(customers[8].Id, vehicles[9].Id, DateTime.Today.AddDays(14)),
            new(customers[9].Id, vehicles[10].Id, DateTime.Today.AddDays(18))
        };

        bookings[0].Complete();
        bookings[1].Complete();
        bookings[2].Confirm();
        bookings[3].Cancel();
        bookings[4].Confirm();

        context.Bookings.AddRange(bookings);

        await context.SaveChangesAsync();
    }
}