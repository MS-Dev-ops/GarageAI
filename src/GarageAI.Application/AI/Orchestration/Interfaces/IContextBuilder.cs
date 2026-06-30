using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Builds business context for an AI request.
/// </summary>
public interface IContextBuilder
{
    Task<AIContext> BuildAsync(
        AIRequest request,
        CancellationToken cancellationToken = default);
}