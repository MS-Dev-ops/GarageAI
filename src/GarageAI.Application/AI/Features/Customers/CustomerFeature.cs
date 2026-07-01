using GarageAI.Application.AI.Features.Customers;
using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.Customers.Queries.GetActiveCustomers;
using GarageAI.Application.Customers.Queries.GetCustomerByEmail;
using GarageAI.Application.Customers.Queries.GetCustomerByName;
using GarageAI.Application.Customers.Queries.GetCustomerByPhone;
using GarageAI.Application.Customers.Queries.GetCustomers;

namespace GarageAI.Infrastructure.AI.Features.Customers;

public sealed class CustomerFeature : ICustomerFeature
{
    private readonly GetCustomersQueryHandler _getCustomersHandler;
    private readonly GetActiveCustomersQueryHandler _getActiveHandler;
    private readonly GetCustomerByNameQueryHandler _getByNameHandler;
    private readonly GetCustomerByPhoneQueryHandler _getByPhoneHandler;
    private readonly GetCustomerByEmailQueryHandler _getByEmailHandler;

    public CustomerFeature(
        GetCustomersQueryHandler getCustomersHandler,
        GetActiveCustomersQueryHandler getActiveHandler,
        GetCustomerByNameQueryHandler getByNameHandler,
        GetCustomerByPhoneQueryHandler getByPhoneHandler,
        GetCustomerByEmailQueryHandler getByEmailHandler)
    {
        _getCustomersHandler = getCustomersHandler;
        _getActiveHandler = getActiveHandler;
        _getByNameHandler = getByNameHandler;
        _getByPhoneHandler = getByPhoneHandler;
        _getByEmailHandler = getByEmailHandler;
    }

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var featureRequest =
            CustomerFeatureDetector.Detect(request.Prompt);

        switch (featureRequest.Intent)
        {
            case CustomerFeatureIntent.CustomerCount:
                {
                    var customers = await _getCustomersHandler.Handle(
                        new GetCustomersQuery());

                    return new AIResponse
                    {
                        Content = $"There are {customers.Count} customers.🔥 CUSTOMER COUNT CASE 🔥"
                    };
                }

            case CustomerFeatureIntent.ListCustomers:
                {
                    var customers = await _getCustomersHandler.Handle(
                        new GetCustomersQuery());

                    return new AIResponse
                    {
                        Content =
                            "Customers\n\n" +
                            string.Join(
                                Environment.NewLine,
                                customers.Select((c, i) =>
                                    $"{i + 1}. {c.FullName}"))
                    };
                }

            case CustomerFeatureIntent.ListActiveCustomers:
                {
                    var customers = await _getActiveHandler.Handle(
                        new GetActiveCustomersQuery());

                    return new AIResponse
                    {
                        Content =
                            "Active Customers\n\n" +
                            string.Join(
                                Environment.NewLine,
                                customers.Select((c, i) =>
                                    $"{i + 1}. {c.FullName}"))
                    };
                }

            case CustomerFeatureIntent.FindCustomerByName:
            case CustomerFeatureIntent.CustomerDetails:
                {
                    if (string.IsNullOrWhiteSpace(featureRequest.Name))
                    {
                        return new AIResponse
                        {
                            Content = "Please provide the customer's name."
                        };
                    }

                    var parts = featureRequest.Name.Split(
                        ' ',
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length < 2)
                    {
                        return new AIResponse
                        {
                            Content = "Please provide the customer's first and last name."
                        };
                    }

                    var customer =
                        await _getByNameHandler.Handle(
                            new GetCustomerByNameQuery
                            {
                                FirstName = parts[0],
                                LastName = parts[1]
                            });

                    if (customer is null)
                    {
                        return new AIResponse
                        {
                            Content = "Customer not found."
                        };
                    }

                    return new AIResponse
                    {
                        Content =
    $"""
Customer

Name: {customer.FullName}
Phone: {customer.Phone}
Email: {customer.Email}
Status: {customer.Status}
"""
                    };
                }

            case CustomerFeatureIntent.FindCustomerByPhone:
                {
                    var customer =
                        await _getByPhoneHandler.Handle(
                            new GetCustomerByPhoneQuery
                            {
                                Phone = featureRequest.Phone ?? ""
                            });

                    if (customer is null)
                    {
                        return new AIResponse
                        {
                            Content = "Customer not found."
                        };
                    }

                    return new AIResponse
                    {
                        Content =
    $"""
Customer

Name: {customer.FullName}
Phone: {customer.Phone}
Email: {customer.Email}
Status: {customer.Status}
"""
                    };
                }

            case CustomerFeatureIntent.FindCustomerByEmail:
                {
                    var customer =
                        await _getByEmailHandler.Handle(
                            new GetCustomerByEmailQuery
                            {
                                Email = featureRequest.Email ?? ""
                            });

                    if (customer is null)
                    {
                        return new AIResponse
                        {
                            Content = "Customer not found."
                        };
                    }

                    return new AIResponse
                    {
                        Content =
    $"""
Customer

Name: {customer.FullName}
Phone: {customer.Phone}
Email: {customer.Email}
Status: {customer.Status}
"""
                    };
                }

            default:
                return new AIResponse
                {
                    Content = "I couldn't understand the customer request."
                };
        }
    }
}