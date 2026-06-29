using GarageAI.Application.ServicePackages.DTOs;
using GarageAI.Application.ServicePackages.Interfaces;

namespace GarageAI.Application.ServicePackages.Queries.GetServicePackages;

public class GetServicePackagesQueryHandler
{
    private readonly IServicePackageRepository _repository;

    public GetServicePackagesQueryHandler(IServicePackageRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ServicePackageDto>> Handle(GetServicePackagesQuery query)
    {
        return await _repository.GetServicePackagesAsync();
    }
}