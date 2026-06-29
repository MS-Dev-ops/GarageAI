using GarageAI.Application.Customers.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Customers;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

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