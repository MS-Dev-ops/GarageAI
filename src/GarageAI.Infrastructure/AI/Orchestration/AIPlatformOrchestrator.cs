using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Orchestration;

public sealed class AIPlatformOrchestrator : IAIPlatformOrchestrator
{
    private readonly IExecutionPolicy _executionPolicy;

    public AIPlatformOrchestrator(
        IExecutionPolicy executionPolicy)
    {
        _executionPolicy = executionPolicy;
    }

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _executionPolicy.ExecuteAsync(
            request,
            cancellationToken);
    }
}