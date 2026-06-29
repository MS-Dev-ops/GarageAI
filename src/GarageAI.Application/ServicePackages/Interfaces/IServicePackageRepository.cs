using GarageAI.Application.ServicePackages.DTOs;

namespace GarageAI.Application.ServicePackages.Interfaces;

public interface IServicePackageRepository
{
    Task<List<ServicePackageDto>> GetServicePackagesAsync();
}