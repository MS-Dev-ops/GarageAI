using GarageAI.Application.Services.DTOs;
using GarageAI.Application.Services.Interfaces;

namespace GarageAI.Application.Services.Queries.GetServices;

public class GetServicesQueryHandler
{
    private readonly IServiceRepository _repository;

    public GetServicesQueryHandler(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ServiceDto>> Handle(GetServicesQuery query)
    {
        return await _repository.GetServicesAsync();
    }
}