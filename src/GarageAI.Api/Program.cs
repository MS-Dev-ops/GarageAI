using GarageAI.Application.AI.Conversation.Ask;
using GarageAI.Application.Bookings.Queries.GetBookings;
using GarageAI.Application.Dashboard.Queries.GetDashboard;
using GarageAI.Application.Mechanics.Queries.GetMechanics;
using GarageAI.Application.ServicePackages.Queries.GetServicePackages;
using GarageAI.Application.Services.Queries.GetServices;
using GarageAI.Infrastructure.Configurations;
using GarageAI.Infrastructure.DependencyInjection;
using GarageAI.Infrastructure.Persistence;
using GarageAI.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddGarageAICloudConfiguration();

builder.Services.AddInfrastructure(builder.Configuration);

//Applications

builder.Services.AddScoped<GetBookingsQueryHandler>();
builder.Services.AddScoped<GetMechanicsQueryHandler>();
builder.Services.AddScoped<GetServicesQueryHandler>();
builder.Services.AddScoped<GetServicePackagesQueryHandler>();
builder.Services.AddScoped<GetDashboardQueryHandler>();
builder.Services.AddScoped<AskConversationQueryHandler>();

builder.Services
    .AddOptions<OpenAIOptions>()
    .Bind(builder.Configuration.GetSection(OpenAIOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

//API
builder.Services.AddControllers();
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
