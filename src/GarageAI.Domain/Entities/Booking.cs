using GarageAI.Domain.Common;
using GarageAI.Domain.Enums;

namespace GarageAI.Domain.Entities;

public class Booking : BaseEntity
{
    private Booking()
    {
    }

    public Booking(
        Guid customerId,
        Guid vehicleId,
        DateTime bookingDate,
        Guid? servicePackageId = null)
    {
        CustomerId = customerId;
        VehicleId = vehicleId;
        BookingDate = bookingDate;
        ServicePackageId = servicePackageId;

        Status = BookingStatus.Pending;
    }

    public Guid CustomerId { get; private set; }

    public Guid VehicleId { get; private set; }

    public Guid? ServicePackageId { get; private set; }

    public DateTime BookingDate { get; private set; }

    public BookingStatus Status { get; private set; }

    // Navigation properties


    public void Confirm()
    {
        Status = BookingStatus.Confirmed;
    }

    public void Complete()
    {
        Status = BookingStatus.Completed;
    }

    public void Cancel()
    {
        Status = BookingStatus.Cancelled;
    }
}