using GarageAI.Application.AI.Features.Customers;
using GarageAI.Application.AI.Features.Dashboard;
using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Local;

public sealed class LocalAIProvider : IAIProvider
{
    private readonly IDashboardFeature _dashboardFeature;
    private readonly ICustomerFeature _customerFeature;

    public LocalAIProvider(
     IDashboardFeature dashboardFeature,
     ICustomerFeature customerFeature)
    {
        _dashboardFeature = dashboardFeature;
        _customerFeature = customerFeature;
    }

    public AIProviderType ProviderType => AIProviderType.Local;

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var dashboardIntent =
            DashboardFeatureDetector.Detect(request.Prompt);

        if (dashboardIntent != DashboardFeatureIntent.Unknown)
        {
            return await _dashboardFeature.ExecuteAsync(
                request,
                cancellationToken);
        }

        var customerIntent =
    CustomerFeatureDetector.Detect(request.Prompt);

        if (customerIntent != CustomerFeatureIntent.Unknown)
        {
            return await _customerFeature.ExecuteAsync(
                request,
                cancellationToken);
        }

        var intent = LocalIntentDetector.Detect(request.Prompt);

        return LocalResponseFactory.Create(intent);
    }
}