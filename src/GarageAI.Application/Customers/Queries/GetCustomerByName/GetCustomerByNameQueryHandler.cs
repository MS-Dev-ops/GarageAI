using GarageAI.Application.Customers.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Customers.Queries.GetCustomerByName;

public sealed class GetCustomerByNameQueryHandler
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByNameQueryHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto?> Handle(
        GetCustomerByNameQuery query)
    {
        var customer = await _repository.GetByNameAsync(
            query.FirstName,
            query.LastName);

        if (customer is null)
            return null;

        return new CustomerDto
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Phone = customer.Phone,
            Email = customer.Email,
            Status = customer.Status.ToString()
        };
    }
}