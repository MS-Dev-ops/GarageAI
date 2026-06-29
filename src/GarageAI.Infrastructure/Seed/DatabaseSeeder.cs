using GarageAI.Infrastructure.Persistence;

namespace GarageAI.Infrastructure.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(GarageDbContext context)
    {
        await CustomerSeeder.SeedAsync(context);

        await VehicleSeeder.SeedAsync(context);

        await ServiceSeeder.SeedAsync(context);

        await ServicePackageSeeder.SeedAsync(context);

        await MechanicSeeder.SeedAsync(context);

        await BookingSeeder.SeedAsync(context);

        await BookingServiceSeeder.SeedAsync(context);

        await BookingMechanicSeeder.SeedAsync(context);
    }
}