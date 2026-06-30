using GarageAI.Application.AI.Orchestration;
using GarageAI.Infrastructure.AI.Orchestration;
using GarageAI.Infrastructure.Configurations;
using GarageAI.Infrastructure.Persistence;
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
        services.AddScoped<IAIOrchestrator, AIOrchestrator>();

        return services;
    }
}