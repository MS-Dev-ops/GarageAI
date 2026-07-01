using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Orchestration;

public sealed class AIProviderResolver : IAIProviderResolver
{
    private readonly IReadOnlyDictionary<AIProviderType, IAIProvider> _providers;

    public AIProviderResolver(IEnumerable<IAIProvider> providers)
    {
        _providers = providers.ToDictionary(p => p.ProviderType);
    }

    public IAIProvider Resolve(AIProviderType providerType)
    {
        if (_providers.TryGetValue(providerType, out var provider))
        {
            return provider;
        }

        throw new InvalidOperationException(
            $"No AI provider registered for '{providerType}'.");
    }
}