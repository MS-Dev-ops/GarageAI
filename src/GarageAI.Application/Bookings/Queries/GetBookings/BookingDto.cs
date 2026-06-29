namespace GarageAI.Application.Bookings.Queries.GetBookings;

public class BookingDto
{
    public Guid Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string RegistrationNumber { get; set; } = string.Empty;

    public string Vehicle { get; set; } = string.Empty;

    public DateTime BookingDate { get; set; }

    public string? PackageName { get; set; }

    public string Status { get; set; } = string.Empty;
}