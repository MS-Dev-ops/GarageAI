using GarageAI.Domain.Common;

namespace GarageAI.Domain.Entities;

public class BookingMechanic : BaseEntity
{
    private BookingMechanic()
    {
    }

    public BookingMechanic(Guid bookingId, Guid mechanicId)
    {
        BookingId = bookingId;
        MechanicId = mechanicId;
    }

    public Guid BookingId { get; private set; }

    public Guid MechanicId { get; private set; }
}