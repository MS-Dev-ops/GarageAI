using GarageAI.Domain.Common;

namespace GarageAI.Domain.Entities;

public class ServicePackage : BaseEntity
{
    private ServicePackage()
    {
    }

    public ServicePackage(
        string name,
        decimal discount)
    {
        Name = name;
        Discount = discount;
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;

    public decimal Discount { get; private set; }

    public bool IsActive { get; private set; }

    public void Deactivate()
    {
        IsActive = false;
    }
}