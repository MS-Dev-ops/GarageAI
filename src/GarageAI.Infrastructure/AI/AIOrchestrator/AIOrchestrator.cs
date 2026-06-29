using GarageAI.Application.AI.Conversation.Ask;
using GarageAI.Application.AI.Orchestration;
using GarageAI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using OpenAI;

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

    public Task<AskConversationResponse> ExecuteAsync(
        AskConversationRequest request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}