using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Builders;

public sealed class ContextBuilder : IContextBuilder
{
    public Task<AIContext> BuildAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var context = new AIContext
        {
            // Future:
            // CustomerId = ...
            // VehicleId = ...
            // BookingId = ...
            // MechanicId = ...
            // WorkshopId = ...
        };

        return Task.FromResult(context);
    }
}