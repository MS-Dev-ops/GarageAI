using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;
using GarageAI.Infrastructure.AI.Local;

namespace GarageAI.Infrastructure.AI.Policies;

public sealed class DefaultExecutionPolicy : IExecutionPolicy
{
    private readonly IAIProviderResolver _providerResolver;

    public DefaultExecutionPolicy(
        IAIProviderResolver providerResolver)
    {
        _providerResolver = providerResolver;
    }

    public async Task<AIResponse> ExecuteAsync(
     AIRequest request,
     CancellationToken cancellationToken = default)
    {
        AIProviderType providerType;

        if (request.Provider.HasValue)
        {
            providerType = request.Provider.Value;
        }
        else
        {
            var intent = LocalIntentDetector.Detect(request.Prompt);

            providerType = intent == LocalIntent.Unknown
                ? AIProviderType.OpenAI
                : AIProviderType.Local;
        }

        var provider = _providerResolver.Resolve(providerType);

        return await provider.ExecuteAsync(
            request,
            cancellationToken);
    }
}