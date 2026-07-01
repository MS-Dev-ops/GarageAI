using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Enums;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Application.AI.Conversation.Ask;

public sealed class AskConversationQueryHandler
{
    private readonly IAIPlatformOrchestrator _orchestrator;

    public AskConversationQueryHandler(
        IAIPlatformOrchestrator orchestrator)
    {
        _orchestrator = orchestrator;
    }

    public async Task<AskConversationResponse> HandleAsync(
        AskConversationQuery query,
        CancellationToken cancellationToken = default)
    {
        var aiRequest = new AIRequest
        {
            Prompt = query.Request.Message,
            RequestType = AIRequestType.Conversation
            
        };

        var aiResponse = await _orchestrator.ExecuteAsync(
            aiRequest,
            cancellationToken);

        return new AskConversationResponse
        {
            Message = aiResponse.Content
        };
    }
}