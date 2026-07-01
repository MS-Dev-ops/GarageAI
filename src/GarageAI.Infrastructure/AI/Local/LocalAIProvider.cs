using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Local;

public sealed class LocalAIProvider : IAIProvider
{
    public AIProviderType ProviderType => AIProviderType.Local;

    public Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var intent = LocalIntentDetector.Detect(request.Prompt);

        var response = LocalResponseFactory.Create(intent);

        return Task.FromResult(response);
    }
}