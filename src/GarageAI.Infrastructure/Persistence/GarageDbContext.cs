using GarageAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Persistence;

public class GarageDbContext : DbContext
{
    public GarageDbContext(DbContextOptions<GarageDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<Service> Services => Set<Service>();

    public DbSet<ServicePackage> ServicePackages => Set<ServicePackage>();

    public DbSet<Mechanic> Mechanics => Set<Mechanic>();
    public DbSet<BookingService> BookingServices => Set<BookingService>();

    public DbSet<BookingMechanic> BookingMechanics => Set<BookingMechanic>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageDbContext).Assembly);
    }
}
