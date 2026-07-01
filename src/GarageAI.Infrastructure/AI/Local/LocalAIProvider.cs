using GarageAI.Application.AI.Features.Dashboard;
using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Local;

public sealed class LocalAIProvider : IAIProvider
{
    private readonly IDashboardFeature _dashboardFeature;

    public LocalAIProvider(
        IDashboardFeature dashboardFeature)
    {
        _dashboardFeature = dashboardFeature;
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

        var intent = LocalIntentDetector.Detect(request.Prompt);

        return LocalResponseFactory.Create(intent);
    }
}