using GarageAI.Domain.Common;

namespace GarageAI.Domain.Entities;

public class BookingService : BaseEntity
{
    private BookingService()
    {
    }

    public BookingService(Guid bookingId, Guid serviceId)
    {
        BookingId = bookingId;
        ServiceId = serviceId;
    }

    public Guid BookingId { get; private set; }

    public Guid ServiceId { get; private set; }
}