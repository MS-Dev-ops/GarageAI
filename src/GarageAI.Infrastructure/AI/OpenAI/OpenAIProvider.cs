using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;
using GarageAI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;

namespace GarageAI.Infrastructure.AI.OpenAI;

public sealed class OpenAIProvider : IAIProvider
{
    private readonly OpenAIClient _client;
    private readonly OpenAIOptions _options;

    public OpenAIProvider(IOptions<OpenAIOptions> options)
    {
        _options = options.Value;
        _client = new OpenAIClient(_options.ApiKey);
    }

    public AIProviderType ProviderType => AIProviderType.OpenAI;

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var chatClient = _client.GetChatClient(_options.Model);

        var messages = new List<ChatMessage>
        {
            new UserChatMessage(request.Prompt)
        };

        ChatCompletion result = await chatClient.CompleteChatAsync(
            messages,
            cancellationToken: cancellationToken);

        var content = result.Content.FirstOrDefault()?.Text;

        if (string.IsNullOrWhiteSpace(content))
        {
            return new AIResponse
            {
                Success = false,
                AIError = "OpenAI returned an empty response."
            };
        }

        return new AIResponse
        {
            Success = true,
            Content = content
        };
    }
}