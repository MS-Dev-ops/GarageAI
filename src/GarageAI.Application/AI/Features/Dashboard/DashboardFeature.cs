using GarageAI.Application.AI.Features.Dashboard;
using GarageAI.Application.AI.Orchestration.Contracts;
using GarageAI.Application.Dashboard.Queries.GetDashboard;

namespace GarageAI.Infrastructure.AI.Features.Dashboard;

public sealed class DashboardFeature : IDashboardFeature
{
    private readonly GetDashboardQueryHandler _handler;

    public DashboardFeature(
        GetDashboardQueryHandler handler)
    {
        _handler = handler;
    }

    public async Task<AIResponse> ExecuteAsync(
        AIRequest request,
        CancellationToken cancellationToken = default)
    {
        var dashboard = await _handler.Handle(
            new GetDashboardQuery());

        var intent = DashboardFeatureDetector.Detect(request.Prompt);

        return intent switch
        {
            DashboardFeatureIntent.CustomerCount =>
                new AIResponse
                {
                    Content = $"There are {dashboard.Customers} customers."
                },

            DashboardFeatureIntent.VehicleCount =>
                new AIResponse
                {
                    Content = $"There are {dashboard.Vehicles} vehicles."
                },

            DashboardFeatureIntent.BookingCount =>
                new AIResponse
                {
                    Content = $"There are {dashboard.BookingsToday} bookings today."
                },

            DashboardFeatureIntent.MechanicCount =>
                new AIResponse
                {
                    Content = $"There are {dashboard.AvailableMechanics} mechanics available."
                },

            _ =>
                new AIResponse
                {
                    Content = "I couldn't understand the dashboard request."
                }
        };
    }
}