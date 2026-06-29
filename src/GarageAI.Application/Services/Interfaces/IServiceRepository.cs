using GarageAI.Application.Services.DTOs;

namespace GarageAI.Application.Services.Interfaces;

public interface IServiceRepository
{
    Task<List<ServiceDto>> GetServicesAsync();
}