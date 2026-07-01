using GarageAI.Application.AI.Conversation.Ask;
using GarageAI.Application.AI.Orchestration.Enums;
using System.Net.Http.Json;

namespace GarageAI.Web.Services;

public class AIApiService
{
    private readonly HttpClient _httpClient;

    public AIApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AskConversationResponse?> AskAsync(
     string message,
     AIProviderType provider)
    {
        var request = new AskConversationRequest
        {
            Message = message,
            Provider = provider
        };

        var response = await _httpClient.PostAsJsonAsync(
            "api/ai/conversation",
            request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AskConversationResponse>();
    }
}