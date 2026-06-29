namespace GarageAI.Application.AI.Conversation.Ask;

public sealed class AskConversationRequest
{
    public Guid UserId { get; init; }

    public Guid SessionId { get; init; }

    public string Message { get; init; } = string.Empty;
}