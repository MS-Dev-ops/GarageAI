using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Determines how an AI request should be executed.
/// </summary>
public interface IExecutionPolicy
{
    Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default);
}