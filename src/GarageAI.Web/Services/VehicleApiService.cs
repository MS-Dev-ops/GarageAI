using GarageAI.Application.Vehicles.DTOs;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class VehicleApiService
{
    private readonly HttpClient _httpClient;

    public VehicleApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<VehicleDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<VehicleDto>>("api/vehicles")
               ?? [];
    }
}