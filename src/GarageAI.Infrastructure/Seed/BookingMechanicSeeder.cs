using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class BookingMechanicSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.BookingMechanics.AnyAsync())
            return;

        var bookings = await context.Bookings.ToListAsync();
        var mechanics = await context.Mechanics.ToListAsync();

        var mike = mechanics.Single(x => x.FirstName == "Mike");
        var james = mechanics.Single(x => x.FirstName == "James");
        var peter = mechanics.Single(x => x.FirstName == "Peter");
        var chris = mechanics.Single(x => x.FirstName == "Chris");

        var bookingMechanics = new List<BookingMechanic>
        {
            new(bookings[0].Id, mike.Id),
            new(bookings[0].Id, james.Id),

            new(bookings[1].Id, peter.Id),

            new(bookings[2].Id, chris.Id),

            new(bookings[3].Id, mike.Id),

            new(bookings[4].Id, james.Id),

            new(bookings[5].Id, peter.Id),

            new(bookings[6].Id, chris.Id),

            new(bookings[7].Id, mike.Id),
            new(bookings[7].Id, peter.Id),

            new(bookings[8].Id, james.Id),

            new(bookings[9].Id, chris.Id)
        };

        context.BookingMechanics.AddRange(bookingMechanics);

        await context.SaveChangesAsync();
    }
}