using GarageAI.Domain.Common;

namespace GarageAI.Domain.Entities;

public class Service : BaseEntity
{
    private Service()
    {
    }

    public Service(
        string name,
        decimal price,
        int durationMinutes)
    {
        Name = name;
        Price = price;
        DurationMinutes = durationMinutes;
    }

    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int DurationMinutes { get; private set; }

    public void UpdatePrice(decimal price)
    {
        Price = price;
    }
}