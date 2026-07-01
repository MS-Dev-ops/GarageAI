using GarageAI.Application.Interfaces;
using GarageAI.Domain.Entities;
using GarageAI.Domain.Enums;
using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GarageAI.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly GarageDbContext _context;

    public CustomerRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .OrderBy(c => c.FirstName)
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer is null)
            return;

        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();
    }
    public async Task<List<Customer>> GetActiveAsync()
    {
        return await _context.Customers
            .Where(c => c.Status == CustomerStatus.Active)
            .OrderBy(c => c.FirstName)
            .ToListAsync();
    }

    public async Task<Customer?> GetByNameAsync(
        string firstName,
        string lastName)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c =>
                c.FirstName == firstName &&
                c.LastName == lastName);
    }

    public async Task<Customer?> GetByPhoneAsync(string phone)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c =>
                c.Phone == phone);
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c =>
                c.Email == email);
    }
}