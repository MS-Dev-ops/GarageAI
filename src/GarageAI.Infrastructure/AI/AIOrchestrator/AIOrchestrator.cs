using GarageAI.Application.AI.Conversation.Ask;
using GarageAI.Application.AI.Orchestration;
using GarageAI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;

namespace GarageAI.Infrastructure.AI.Orchestration;

public sealed class AIOrchestrator : IAIOrchestrator
{
    private readonly OpenAIClient _client;
    private readonly OpenAIOptions _options;


    public AIOrchestrator(IOptions<OpenAIOptions> options)
    {
        _options = options.Value;
        _client = new OpenAIClient(_options.ApiKey);
    }

    public async Task<AskConversationResponse> ExecuteAsync(
        AskConversationRequest request,
        CancellationToken cancellationToken = default)
    {
        
        var chatClient = _client.GetChatClient(_options.Model);
        var messages = new List<ChatMessage>
            {
                new UserChatMessage(request.Message)
            };

        ChatCompletion result = await chatClient.CompleteChatAsync(
     messages,
     cancellationToken: cancellationToken);

      
        return new AskConversationResponse
        {
            Message = result.Content[0].Text
        };


    }
}