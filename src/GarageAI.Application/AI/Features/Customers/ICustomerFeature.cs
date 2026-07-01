using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Application.AI.Features.Customers;

public interface ICustomerFeature
{
    Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default);
}