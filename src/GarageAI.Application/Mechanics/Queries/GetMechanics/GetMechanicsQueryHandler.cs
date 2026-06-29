using GarageAI.Application.Mechanics.DTOs;
using GarageAI.Application.Mechanics.Interfaces;

namespace GarageAI.Application.Mechanics.Queries.GetMechanics;

public class GetMechanicsQueryHandler
{
    private readonly IMechanicRepository _mechanicRepository;

    public GetMechanicsQueryHandler(IMechanicRepository mechanicRepository)
    {
        _mechanicRepository = mechanicRepository;
    }

    public async Task<List<MechanicDto>> Handle(GetMechanicsQuery query)
    {
        return await _mechanicRepository.GetMechanicsAsync();
    }
}