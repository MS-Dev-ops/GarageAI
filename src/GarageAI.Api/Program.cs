using GarageAI.Application.Bookings;
using GarageAI.Application.Bookings.Interfaces;
using GarageAI.Application.Bookings.Queries.GetBookings;
using GarageAI.Application.Customers;
using GarageAI.Application.Dashboard.Interfaces;
using GarageAI.Application.Dashboard.Queries.GetDashboard;
using GarageAI.Application.Interfaces;
using GarageAI.Application.Mechanics.Interfaces;
using GarageAI.Application.Mechanics.Queries.GetMechanics;
using GarageAI.Application.ServicePackages.Interfaces;
using GarageAI.Application.ServicePackages.Queries.GetServicePackages;
using GarageAI.Application.Services.Interfaces;
using GarageAI.Application.Services.Queries.GetServices;
using GarageAI.Application.Vehicles;
using GarageAI.Infrastructure.Persistence;
using GarageAI.Infrastructure.Repositories;
using GarageAI.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using GarageAI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<GarageDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<VehicleService>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();


builder.Services.AddScoped<GetBookingsQueryHandler>();

builder.Services.AddScoped<IMechanicRepository, MechanicRepository>();
builder.Services.AddScoped<GetMechanicsQueryHandler>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<GetServicesQueryHandler>();

builder.Services.AddScoped<IServicePackageRepository, ServicePackageRepository>();
builder.Services.AddScoped<GetServicePackagesQueryHandler>();

builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<GetDashboardQueryHandler>();

builder.Services.Configure<OpenAIOptions>(
    builder.Configuration.GetSection(OpenAIOptions.SectionName));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
// Database migration and seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GarageDbContext>();

    await db.Database.MigrateAsync();

    await DatabaseSeeder.SeedAsync(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
