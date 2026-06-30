using Azure.Identity;
using GarageAI.Application.AI.Conversation.Ask;
using GarageAI.Application.AI.Orchestration;
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
using GarageAI.Infrastructure.AI.Orchestration;
using GarageAI.Infrastructure.Configurations;
using GarageAI.Infrastructure.DependencyInjection;
using GarageAI.Infrastructure.Persistence;
using GarageAI.Infrastructure.Repositories;
using GarageAI.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddGarageAICloudConfiguration();
Console.WriteLine("Model from App Config:");
Console.WriteLine(builder.Configuration["OpenAI:Model"]);

builder.Services.AddInfrastructure(builder.Configuration);
// Register DbContext


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

builder.Services
    .AddOptions<OpenAIOptions>()
    .Bind(builder.Configuration.GetSection(OpenAIOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<AskConversationQueryHandler>();



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
