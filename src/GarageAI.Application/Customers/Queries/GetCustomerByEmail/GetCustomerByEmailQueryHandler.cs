using GarageAI.Application.Customers.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Customers.Queries.GetCustomerByEmail;

public sealed class GetCustomerByEmailQueryHandler
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByEmailQueryHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto?> Handle(
        GetCustomerByEmailQuery query)
    {
        var customer =
            await _repository.GetByEmailAsync(query.Email);

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