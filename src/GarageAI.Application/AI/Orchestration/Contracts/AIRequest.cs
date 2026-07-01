using GarageAI.Application.AI.Orchestration.Enums;
using System;

namespace GarageAI.Application.AI.Orchestration.Contracts;

public sealed class AIRequest
{
    /// <summary>
    /// The user's request or generated prompt.
    /// </summary>
    public required string Prompt { get; init; }

    /// <summary>
    /// The AI capability being requested.
    /// </summary>
    public required AIRequestType RequestType { get; init; }

    /// <summary>
    /// Optional conversation identifier.
    /// Used for chat and memory.
    /// </summary>
    public Guid? ConversationId { get; init; }

    /// <summary>
    /// Optional agent responsible for the request.
    /// </summary>
    public string? AgentType { get; init; }

    public AIContext Context { get; init; } = new();

    public AIProviderType? Provider { get; init; }

}