using GarageAI.Domain.Common;
using GarageAI.Domain.Enums;

namespace GarageAI.Domain.Entities;

public class Customer : BaseEntity
{

    private Customer()
    {
        // Required by EF Core
    }

    public Customer(
        string firstName,
        string lastName,
        string phone,
        string? email = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;

        Status = CustomerStatus.Active;
    }
   
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Phone { get; private set; } = string.Empty;

    public string? Email { get; private set; }

    public CustomerStatus Status { get; private set; }

    public void UpdatePhone(string phone)
    {
        Phone = phone;
    }

    public void UpdateEmail(string? email)
    {
        Email = email;
    }

    public void Archive()
    {
        Status = CustomerStatus.Archived;
    }
}
