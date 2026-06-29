using GarageAI.Domain.Common;
using GarageAI.Domain.Enums;

namespace GarageAI.Domain.Entities;

public class Vehicle : BaseEntity
{
    private Vehicle()
    {
    }

    public Vehicle(
        Guid customerId,
        string registrationNumber,
        string make,
        string model,
        int year,
        int mileage)
    {
        CustomerId = customerId;
        RegistrationNumber = registrationNumber;
        Make = make;
        Model = model;
        Year = year;
        Mileage = mileage;

        Status = VehicleStatus.Active;
    }

    public Guid CustomerId { get; private set; }

    public string RegistrationNumber { get; private set; } = string.Empty;

    public string Make { get; private set; } = string.Empty;

    public string Model { get; private set; } = string.Empty;

    public int Year { get; private set; }

    public int Mileage { get; private set; }


    public VehicleStatus Status { get; private set; }

    public void UpdateMileage(int mileage)
    {
        Mileage = mileage;
    }

    public void Archive()
    {
        Status = VehicleStatus.Archived;
    }
}