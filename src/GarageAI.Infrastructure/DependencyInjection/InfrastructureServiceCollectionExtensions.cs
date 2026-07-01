using GarageAI.Application.AI.Features.Customers;
using GarageAI.Application.AI.Features.Dashboard;
using GarageAI.Application.AI.Orchestration.Interfaces;
using GarageAI.Application.Bookings.Interfaces;
using GarageAI.Application.Customers;
using GarageAI.Application.Customers.Queries.GetActiveCustomers;
using GarageAI.Application.Customers.Queries.GetCustomerByEmail;
using GarageAI.Application.Customers.Queries.GetCustomerByName;
using GarageAI.Application.Customers.Queries.GetCustomerByPhone;
using GarageAI.Application.Customers.Queries.GetCustomers;
using GarageAI.Application.Interfaces;
using GarageAI.Application.Mechanics.Interfaces;
using GarageAI.Application.ServicePackages.Interfaces;
using GarageAI.Application.Services.Interfaces;
using GarageAI.Application.Vehicles;
using GarageAI.Infrastructure.AI.Builders;
using GarageAI.Infrastructure.AI.Features.Customers;
using GarageAI.Infrastructure.AI.Features.Dashboard;
using GarageAI.Infrastructure.AI.Local;
using GarageAI.Infrastructure.AI.OpenAI;
using GarageAI.Infrastructure.AI.Orchestration;
using GarageAI.Infrastructure.AI.Policies;
using GarageAI.Infrastructure.Configurations;
using GarageAI.Infrastructure.Persistence;
using GarageAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GarageAI.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database
        services.AddDbContext<GarageDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // OpenAI Configuration
        services
            .AddOptions<OpenAIOptions>()
            .Bind(configuration.GetSection(OpenAIOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // AI

        services.AddScoped<IAIProvider, OpenAIProvider>();

        // AI Platform
        services.AddScoped<IAIProviderResolver, AIProviderResolver>();
        services.AddScoped<IExecutionPolicy, DefaultExecutionPolicy>();
        services.AddScoped<IAIPlatformOrchestrator, AIPlatformOrchestrator>();
        services.AddScoped<IContextBuilder, ContextBuilder>();
        services.AddScoped<IPromptBuilder, PromptBuilder>();
        services.AddScoped<IAIProvider, LocalAIProvider>();

        //AI Features
        services.AddScoped<IDashboardFeature, DashboardFeature>();
        services.AddScoped<ICustomerFeature, CustomerFeature>();



        //Repositories
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IMechanicRepository, MechanicRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IServicePackageRepository, ServicePackageRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();

        services.AddScoped<CustomerService>();
        services.AddScoped<VehicleService>();

        //QueryHandlers
        services.AddScoped<GetCustomersQueryHandler>();
        services.AddScoped<GetActiveCustomersQueryHandler>();
        services.AddScoped<GetCustomerByNameQueryHandler>();
        services.AddScoped<GetCustomerByPhoneQueryHandler>();
        services.AddScoped<GetCustomerByEmailQueryHandler>();
        return services;
    }
}