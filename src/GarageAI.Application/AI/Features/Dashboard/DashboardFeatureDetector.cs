namespace GarageAI.Application.AI.Features.Dashboard;

public static class DashboardFeatureDetector
{
    public static DashboardFeatureIntent Detect(string prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
            return DashboardFeatureIntent.Unknown;

        var lower = prompt.ToLowerInvariant();

        // Dashboard requests only
        if (!(lower.Contains("dashboard") ||
              lower.Contains("overview") ||
              lower.Contains("summary") ||
              lower.Contains("statistics") ||
              lower.Contains("stats")))
        {
            return DashboardFeatureIntent.Unknown;
        }

        if (lower.Contains("customer"))
            return DashboardFeatureIntent.CustomerCount;

        if (lower.Contains("vehicle"))
            return DashboardFeatureIntent.VehicleCount;

        if (lower.Contains("booking"))
            return DashboardFeatureIntent.BookingCount;

        if (lower.Contains("mechanic"))
            return DashboardFeatureIntent.MechanicCount;

        // Generic dashboard request
        return DashboardFeatureIntent.Unknown;
    }
}