using GarageAI.Application.Interfaces;
using GarageAI.Application.Vehicles.DTOs;

namespace GarageAI.Application.Vehicles;

public class VehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<List<VehicleDto>> GetAllAsync()
    {
        var vehicles = await _vehicleRepository.GetAllAsync();

        return vehicles.Select(v => new VehicleDto
        {
            Id = v.Id,
            RegistrationNumber = v.RegistrationNumber,
            Make = v.Make,
            Model = v.Model,
            Year = v.Year,
            Mileage = v.Mileage,
            Status = v.Status.ToString()
        }).ToList();
    }
}