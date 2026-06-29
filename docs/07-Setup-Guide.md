\# Setup Guide



Version: 1.0



\---



\# Requirements



Visual Studio 2022



.NET 9 SDK



SQL Server



Git



Azure CLI



Docker Desktop



Ollama (optional)



\---



\# Clone Repository



git clone



\---



\# Restore Packages



dotnet restore



\---



\# Apply Database



dotnet ef database update



\---



\# Run API



GarageAI.Api



\---



\# Run Web



GarageAI.Web



\---



\# AI Configuration



Configure



OpenAI



Azure OpenAI



Ollama



inside appsettings.



Never commit secrets.



Use User Secrets or Azure Key Vault.



\---



\# Documentation



Read



00-Vision.md



01-Architecture.md



02-Engineering-Rules.md



03-AI-Platform.md



before contributing.

