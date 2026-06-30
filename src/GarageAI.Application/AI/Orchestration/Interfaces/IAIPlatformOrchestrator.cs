using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Orchestration.Interfaces;

/// <summary>
/// Coordinates the execution of AI requests.
/// 
/// The orchestrator is responsible for routing requests through the AI platform,
/// including execution policy, context building, prompt building, provider
/// selection and future tool execution.
///
/// The orchestrator never contains provider-specific logic.
/// </summary>
public interface IAIPlatformOrchestrator
{
    /// <summary>
    /// Executes an AI request and returns the result.
    /// </summary>
    /// <param name="request">
    /// The AI request to execute.
    /// </param>
    /// <param name="cancellationToken">
    /// Cancellation token.
    /// </param>
    /// <returns>
    /// The AI response.
    /// </returns>
    Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default);
}