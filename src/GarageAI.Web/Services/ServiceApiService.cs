using GarageAI.Application.Services.DTOs;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class ServiceApiService
{
    private readonly HttpClient _httpClient;

    public ServiceApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ServiceDto>> GetServicesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ServiceDto>>("api/services")
               ?? [];
    }
}