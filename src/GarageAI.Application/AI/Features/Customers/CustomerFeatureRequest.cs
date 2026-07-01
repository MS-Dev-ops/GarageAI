namespace GarageAI.Application.AI.Features.Customers;

public sealed class CustomerFeatureRequest
{
    public CustomerFeatureIntent Intent { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}