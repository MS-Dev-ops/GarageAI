using GarageAI.Application.Dashboard.DTOs;
using GarageAI.Application.Interfaces;

namespace GarageAI.Application.Dashboard.Queries.GetDashboard;

public class GetDashboardQueryHandler
{
    private readonly IDashboardRepository _repository;

    public GetDashboardQueryHandler(IDashboardRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardDto> Handle(GetDashboardQuery query)
    {
        return await _repository.GetDashboardAsync();
    }
}