using GarageAI.Application.Bookings.Queries.GetBookings;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class BookingApiService
{
    private readonly HttpClient _httpClient;

    public BookingApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BookingDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<BookingDto>>("api/bookings")
               ?? [];
    }
}