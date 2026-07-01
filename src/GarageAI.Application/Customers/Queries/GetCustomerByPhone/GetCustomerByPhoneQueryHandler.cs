using GarageAI.Application.Customers.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Customers.Queries.GetCustomerByPhone;

public sealed class GetCustomerByPhoneQueryHandler
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByPhoneQueryHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto?> Handle(
        GetCustomerByPhoneQuery query)
    {
        var customer =
            await _repository.GetByPhoneAsync(query.Phone);

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