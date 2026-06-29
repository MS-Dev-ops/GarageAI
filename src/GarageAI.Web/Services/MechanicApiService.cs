using GarageAI.Application.Mechanics.DTOs;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class MechanicApiService
{
    private readonly HttpClient _httpClient;

    public MechanicApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MechanicDto>> GetMechanicsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<MechanicDto>>("api/mechanics")
               ?? [];
    }
}