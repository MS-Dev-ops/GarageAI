using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.AI.Orchestration.Interfaces;

namespace GarageAI.Infrastructure.AI.Orchestration;

public sealed class AIPlatformOrchestrator : IAIPlatformOrchestrator
{
    private readonly IContextBuilder _contextBuilder;
    private readonly IPromptBuilder _promptBuilder;
    private readonly IExecutionPolicy _executionPolicy;

    public AIPlatformOrchestrator(
        IContextBuilder contextBuilder,
        IPromptBuilder promptBuilder,
        IExecutionPolicy executionPolicy)
    {
        _contextBuilder = contextBuilder;
        _promptBuilder = promptBuilder;
        _executionPolicy = executionPolicy;
    }

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var context = await _contextBuilder.BuildAsync(
            request,
            cancellationToken);

        var prompt = await _promptBuilder.BuildAsync(
            request,
            context,
            cancellationToken);

        var enrichedRequest = new AIRequest
        {
            Prompt = prompt,
            RequestType = request.RequestType,
            ConversationId = request.ConversationId,
            AgentType = request.AgentType,
            Context = context
        };

        return await _executionPolicy.ExecuteAsync(
            enrichedRequest,
            cancellationToken);
    }
}