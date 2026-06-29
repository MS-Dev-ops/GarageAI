using GarageAI.Domain.Entities;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Seed;

public static class BookingServiceSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        if (await context.BookingServices.AnyAsync())
            return;

        var bookings = await context.Bookings.ToListAsync();
        var services = await context.Services.ToListAsync();

        var mot = services.Single(x => x.Name == "MOT");
        var interim = services.Single(x => x.Name == "Interim Service");
        var full = services.Single(x => x.Name == "Full Service");
        var major = services.Single(x => x.Name == "Major Service");
        var oil = services.Single(x => x.Name == "Oil Change");
        var brakes = services.Single(x => x.Name == "Brake Inspection");
        var aircon = services.Single(x => x.Name == "Air Conditioning Service");
        var alignment = services.Single(x => x.Name == "Wheel Alignment");

        var bookingServices = new List<BookingService>
        {
            new(bookings[0].Id, mot.Id),
            new(bookings[0].Id, oil.Id),

            new(bookings[1].Id, full.Id),

            new(bookings[2].Id, major.Id),
            new(bookings[2].Id, brakes.Id),

            new(bookings[3].Id, interim.Id),

            new(bookings[4].Id, mot.Id),
            new(bookings[4].Id, alignment.Id),

            new(bookings[5].Id, oil.Id),

            new(bookings[6].Id, aircon.Id),

            new(bookings[7].Id, brakes.Id),

            new(bookings[8].Id, full.Id),
            new(bookings[8].Id, alignment.Id),

            new(bookings[9].Id, mot.Id)
        };

        context.BookingServices.AddRange(bookingServices);

        await context.SaveChangesAsync();
    }
}