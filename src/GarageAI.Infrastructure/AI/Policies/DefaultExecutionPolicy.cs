using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;

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
        // V1 Policy
        // All requests are executed by OpenAI.
        // Future versions will route to Local, Azure, etc.
        var provider = _providerResolver.Resolve(AIProviderType.OpenAI);

        return await provider.ExecuteAsync(
            request,
            cancellationToken);
    }
}