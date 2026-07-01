using GarageAI.Application.Dashboard.DTOs;

namespace GarageAI.Application.Interfaces;

public interface IDashboardRepository
{
    Task<DashboardDto> GetDashboardAsync();
}