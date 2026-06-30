using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;

namespace GarageAI.Application.AI.Orchestration.Models;

/// <summary>
/// Represents the result returned by an AI provider.
/// </summary>
public sealed class AIProviderResult
{
    /// <summary>
    /// Provider that processed the request.
    /// </summary>
    public required AIProviderType Provider { get; init; }

    /// <summary>
    /// Response returned by the provider.
    /// </summary>
    public required AIResponse Response { get; init; }
}