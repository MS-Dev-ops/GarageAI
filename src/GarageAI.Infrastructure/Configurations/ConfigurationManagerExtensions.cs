using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace GarageAI.Infrastructure.Configurations;

public static class ConfigurationManagerExtensions
{
    public static ConfigurationManager AddGarageAICloudConfiguration(
        this ConfigurationManager configuration)
    {
       
        var credential = new DefaultAzureCredential();

        var appConfigEndpoint = configuration["AzureAppConfiguration:Endpoint"];

        if (!string.IsNullOrWhiteSpace(appConfigEndpoint))
        {
            configuration.AddAzureAppConfiguration(options =>
            {
                options.Connect(
                    new Uri(appConfigEndpoint),
                    credential);
            });
        }

        var keyVaultUri = configuration["AzureKeyVault:VaultUri"];

        if (!string.IsNullOrWhiteSpace(keyVaultUri))
        {
            configuration.AddAzureKeyVault(
                new Uri(keyVaultUri),
                credential);
        }

        return configuration;
    }
}