using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Determines how an AI request should be executed.
/// </summary>
public interface IExecutionPolicy
{
    /// <summary>
    /// Selects the appropriate AI provider for a request.
    /// </summary>
    IAIProvider SelectProvider(AIRequest request);
}