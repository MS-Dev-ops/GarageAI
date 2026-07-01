using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Builders;

public sealed class PromptBuilder : IPromptBuilder
{
    public Task<string> BuildAsync(
        AIRequest request,
        AIContext context,
        CancellationToken cancellationToken = default)
    {
        // V1
        // Return the user's prompt unchanged.
        // Future versions will enrich it with customer,
        // vehicle, booking and workshop context.

        return Task.FromResult(request.Prompt);
    }
}