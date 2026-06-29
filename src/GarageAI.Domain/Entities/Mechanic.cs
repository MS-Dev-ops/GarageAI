using GarageAI.Domain.Common;

namespace GarageAI.Domain.Entities;

public class Mechanic : BaseEntity
{
    private Mechanic()
    {
    }

    public Mechanic(
        string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        IsAvailable = true;
    }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public bool IsAvailable { get; private set; }

    public void Assign()
    {
        IsAvailable = false;
    }

    public void Release()
    {
        IsAvailable = true;
    }
}