using GarageAI.Application.AI.Orchestration.Contracts;

namespace GarageAI.Infrastructure.AI.Local;

public static class LocalResponseFactory
{
    public static AIResponse Create(LocalIntent intent)
    {
        return intent switch
        {
            LocalIntent.Greeting => new AIResponse
            {
                Success = true,
                Content = "👋 Hello! Welcome to GarageAI. How can I help you today?"
            },

            LocalIntent.Thanks => new AIResponse
            {
                Success = true,
                Content = "You're welcome! Happy to help."
            },

            LocalIntent.Goodbye => new AIResponse
            {
                Success = true,
                Content = "Goodbye! Have a great day."
            },

            LocalIntent.Help => new AIResponse
            {
                Success = true,
                Content = """
I can help you with:

• Bookings
• Customers
• Vehicles
• Services
• Reports
• AI assistance
"""
            },

            _ => new AIResponse
            {
                Success = false
            }
        };
    }
}