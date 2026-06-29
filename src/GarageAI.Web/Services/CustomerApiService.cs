using GarageAI.Application.Customers.DTOs;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class CustomerApiService
{
    private readonly HttpClient _httpClient;

    public CustomerApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<CustomerDto>>("api/customers")
               ?? [];
    }
}