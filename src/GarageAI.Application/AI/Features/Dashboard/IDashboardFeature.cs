using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Features.Dashboard;

public interface IDashboardFeature
{
    Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default);
}