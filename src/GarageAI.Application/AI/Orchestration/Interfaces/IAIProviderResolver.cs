using GarageAI.Application.AI.Orchestration.Enums;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Resolves AI provider implementations.
/// </summary>
public interface IAIProviderResolver
{
    /// <summary>
    /// Resolves the provider for the specified provider type.
    /// </summary>
    IAIProvider Resolve(AIProviderType providerType);
}