using System.ComponentModel.DataAnnotations;

namespace GarageAI.Infrastructure.Configurations;

public class OpenAIOptions
{
    public const string SectionName = "OpenAI";

    [Required]
    public string ApiKey { get; set; } = string.Empty;
    [Required]
    public string Model { get; set; } = string.Empty;
}