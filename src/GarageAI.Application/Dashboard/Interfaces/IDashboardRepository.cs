using GarageAI.Application.Dashboard.DTOs;

namespace GarageAI.Application.Dashboard.Interfaces;

public interface IDashboardRepository
{
    Task<DashboardDto> GetDashboardAsync();
}