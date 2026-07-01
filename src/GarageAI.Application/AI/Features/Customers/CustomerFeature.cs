using GarageAI.Application.AI.Features.Customers;
using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.Customers.Queries.GetCustomers;

namespace GarageAI.Infrastructure.AI.Features.Customers;

public sealed class CustomerFeature : ICustomerFeature
{
    private readonly GetCustomersQueryHandler _handler;

    public CustomerFeature(
        GetCustomersQueryHandler handler)
    {
        _handler = handler;
    }

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var customers = await _handler.Handle(
            new GetCustomersQuery());

        var intent = CustomerFeatureDetector.Detect(request.Prompt);

        return intent switch
        {
            CustomerFeatureIntent.CustomerCount =>
                new AIResponse
                {
                    Content = $"There are {customers.Count} customers."
                },

            CustomerFeatureIntent.ListCustomers =>
                new AIResponse
                {
                    Content = string.Join(
                        Environment.NewLine,
                        customers.Select(c => $"{c.FullName}"))
                },

            _ => new AIResponse
            {
                Content = "I couldn't understand the customer request."
            }
        };
    }
}