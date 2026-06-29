namespace GarageAI.Domain.Common;
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedOn = DateTime.UtcNow;
    }

    public Guid Id { get; protected set; }

    public DateTime CreatedOn { get; protected set; }

    public string CreatedBy { get; protected set; } = string.Empty;

    public DateTime? ModifiedOn { get; protected set; }

    public string? ModifiedBy { get; protected set; }
}
