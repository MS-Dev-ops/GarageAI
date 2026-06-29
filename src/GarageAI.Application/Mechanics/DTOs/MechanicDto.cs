namespace GarageAI.Application.Mechanics.DTOs;

public class MechanicDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Specialization { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}