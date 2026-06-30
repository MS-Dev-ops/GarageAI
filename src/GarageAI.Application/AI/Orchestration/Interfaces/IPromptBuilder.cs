using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Builds the final prompt sent to an AI provider.
/// </summary>
public interface IPromptBuilder
{
    Task<string> BuildAsync(
        AIRequest request,
        AIContext context,
        CancellationToken cancellationToken = default);
}