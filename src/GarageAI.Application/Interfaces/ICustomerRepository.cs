using GarageAI.Domain.Entities;

namespace GarageAI.Application.Interfaces;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();

    Task<List<Customer>> GetActiveAsync();

    Task<Customer?> GetByIdAsync(Guid id);

    Task<Customer?> GetByNameAsync(
        string firstName,
        string lastName);

    Task<Customer?> GetByPhoneAsync(string phone);

    Task<Customer?> GetByEmailAsync(string email);

    Task AddAsync(Customer customer);

    Task UpdateAsync(Customer customer);

    Task DeleteAsync(Guid id);
}