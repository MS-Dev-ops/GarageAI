namespace GarageAI.Application.AI.Orchestration.Contracts;

public sealed class AIContext
{
    public Guid? CustomerId { get; init; }

    public Guid? VehicleId { get; init; }

    public Guid? BookingId { get; init; }

    public Guid? MechanicId { get; init; }

    public Guid? WorkshopId { get; init; }
}
