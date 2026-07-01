namespace GarageAI.Infrastructure.AI.Local;

public static class LocalIntentDetector
{
    public static LocalIntent Detect(string prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
            return LocalIntent.Unknown;

        prompt = prompt.Trim().ToLowerInvariant();

        if (prompt is "hi" or "hello" or "hey" or "good morning" or "good afternoon")
            return LocalIntent.Greeting;

        if (prompt is "thanks" or "thank you")
            return LocalIntent.Thanks;

        if (prompt is "bye" or "goodbye")
            return LocalIntent.Goodbye;

        if (prompt is "help")
            return LocalIntent.Help;

        return LocalIntent.Unknown;
    }
}