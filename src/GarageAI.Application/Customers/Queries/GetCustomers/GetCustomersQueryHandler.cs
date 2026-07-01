using GarageAI.Application.Customers.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Customers.Queries.GetCustomers;

public sealed class GetCustomersQueryHandler
{
    private readonly ICustomerRepository _repository;

    public GetCustomersQueryHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerDto>> Handle(
        GetCustomersQuery query)
    {
        var customers = await _repository.GetAllAsync();

        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            FullName = $"{c.FirstName} {c.LastName}",
            Phone = c.Phone,
            Email = c.Email,
            Status = c.Status.ToString()
        }).ToList();
    }
}