using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Represents an AI provider implementation.
/// </summary>
public interface IAIProvider
{
    /// <summary>
    /// Gets the provider type.
    /// </summary>
    AIProviderType ProviderType { get; }

    /// <summary>
    /// Executes an AI request.
    /// </summary>
    Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default);
}