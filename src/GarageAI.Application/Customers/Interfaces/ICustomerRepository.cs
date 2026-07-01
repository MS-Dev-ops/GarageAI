using GarageAI.Application.Customers.DTOs;

namespace GarageAI.Application.Customers.Interfaces;

public interface ICustomerRepository
{
    Task<List<CustomerDto>> GetAllAsync();
}