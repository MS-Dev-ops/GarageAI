using GarageAI.Application.AI.Orchestration;

namespace GarageAI.Application.AI.Conversation.Ask;

public sealed class AskConversationQueryHandler
{
    private readonly IAIOrchestrator _orchestrator;

    public AskConversationQueryHandler(IAIOrchestrator orchestrator)
    {
        _orchestrator = orchestrator;
    }

    public async Task<AskConversationResponse> HandleAsync(
        AskConversationQuery query,
        CancellationToken cancellationToken = default)
    {
        return await _orchestrator.ExecuteAsync(
            query.Request,
            cancellationToken);
    }
}