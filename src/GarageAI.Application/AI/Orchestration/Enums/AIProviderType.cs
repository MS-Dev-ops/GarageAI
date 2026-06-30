namespace GarageAI.Application.AI.Orchestration.Enums;

/// <summary>
/// Identifies the AI provider that processed a request.
/// </summary>
public enum AIProviderType
{
    /// <summary>
    /// Local deterministic processing.
    /// Used for greetings, rules, routing and other logic that
    /// does not require an LLM.
    /// </summary>
    Local = 1,

    /// <summary>
    /// OpenAI cloud provider.
    /// </summary>
    OpenAI = 2,

    /// <summary>
    /// Azure OpenAI cloud provider.
    /// </summary>
    AzureOpenAI = 3
}