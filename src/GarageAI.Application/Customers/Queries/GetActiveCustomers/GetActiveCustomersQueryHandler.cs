using GarageAI.Application.Customers.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Customers.Queries.GetActiveCustomers;

public sealed class GetActiveCustomersQueryHandler
{
    private readonly ICustomerRepository _repository;

    public GetActiveCustomersQueryHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerDto>> Handle(
        GetActiveCustomersQuery query)
    {
        var customers = await _repository.GetActiveAsync();

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