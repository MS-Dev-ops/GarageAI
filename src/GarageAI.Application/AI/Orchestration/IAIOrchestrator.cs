using GarageAI.Application.AI.Conversation.Ask;

namespace GarageAI.Application.AI.Orchestration;

public interface IAIOrchestrator
{
    Task<AskConversationResponse> ExecuteAsync(
        AskConversationRequest request,
        CancellationToken cancellationToken = default);
}