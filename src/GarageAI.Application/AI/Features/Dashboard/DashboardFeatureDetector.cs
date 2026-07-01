namespace GarageAI.Application.AI.Features.Dashboard;

public static class DashboardFeatureDetector
{
    public static DashboardFeatureIntent Detect(string prompt)
    {
        prompt = prompt.ToLowerInvariant();

        if (prompt.Contains("customer"))
            return DashboardFeatureIntent.CustomerCount;

        if (prompt.Contains("vehicle"))
            return DashboardFeatureIntent.VehicleCount;

        if (prompt.Contains("booking"))
            return DashboardFeatureIntent.BookingCount;

        if (prompt.Contains("mechanic"))
            return DashboardFeatureIntent.MechanicCount;

        return DashboardFeatureIntent.Unknown;
    }
}