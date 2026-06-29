using GarageAI.Application.Customers.DTOs;

namespace GarageAI.Application.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync();
}
