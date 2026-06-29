using GarageAI.Application.Dashboard.DTOs;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class DashboardApiService
{
    private readonly HttpClient _httpClient;

    public DashboardApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        return await _httpClient.GetFromJsonAsync<DashboardDto>("api/dashboard")
               ?? new DashboardDto();
    }
}