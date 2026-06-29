namespace GarageAI.Application.ServicePackages.DTOs;

public class ServicePackageDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Discount { get; set; }

    public bool IsActive { get; set; }
}