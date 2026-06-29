using GarageAI.Application.ServicePackages.DTOs;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class ServicePackageApiService
{
    private readonly HttpClient _httpClient;

    public ServicePackageApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ServicePackageDto>> GetServicePackagesAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<ServicePackageDto>>("api/servicepackages")
            ?? [];
    }
}