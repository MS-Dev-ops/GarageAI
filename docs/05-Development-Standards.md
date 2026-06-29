\# Development Standards



Version: 1.0

Status: Approved

Owner: GarageAI Engineering Team



\---



\# Purpose



This document defines the development standards used throughout GarageAI.



These standards ensure consistency across all projects and contributors.



\---



\# Solution Structure



GarageAI



├── docs

├── src

├── tests

├── scripts

├── assets

└── GarageAI.sln



\---



\# Project Structure



GarageAI.Domain



Business rules only.



Contains:



\- Entities

\- Value Objects

\- Domain Events

\- Domain Services



Never references other projects.



\---



GarageAI.Application



Business use cases.



Contains:



\- Commands

\- Queries

\- Handlers

\- Contracts

\- DTOs

\- Interfaces



Never references Infrastructure.



\---



GarageAI.Infrastructure



Technology implementations.



Contains:



\- Entity Framework

\- OpenAI

\- Azure SDK

\- Repositories

\- External Services



Implements Application contracts.



\---



GarageAI.Api



HTTP endpoints only.



No business logic.



\---



GarageAI.Web



Presentation only.



No business logic.



\---



\# Vertical Slice



Every feature owns everything required for that feature.



Example



Bookings



Commands



Queries



DTOs



Interfaces



Validators



Controllers remain thin.



\---



\# Naming



Use business language.



Good



Customer



Booking



Conversation



Vehicle



Avoid



Manager



Helper



Processor



Engine



RepositoryManager



\---



\# Requests



Commands change state.



Queries return data.



Every request has one handler.



\---



\# DTO Rules



DTOs belong to the feature that owns them.



DTOs are not shared between unrelated features unless there is a strong business reason.



\---



\# Dependency Injection



Constructor Injection only.



Never instantiate infrastructure services inside business logic.



\---



\# Configuration



All configuration must use strongly typed Options.



No magic strings.



No hardcoded API keys.



\---



\# Async



Use async throughout.



Avoid blocking calls.



Always propagate CancellationToken where appropriate.



\---



\# Error Handling



Handle expected errors.



Do not swallow exceptions.



Log unexpected failures.



\---



\# Logging



Application logs business events.



Infrastructure logs technical events.



Sensitive information must never be logged.



\---



\# Testing



Business logic should be testable without databases or external AI providers.



Mock contracts.



Never mock business logic.



\---



\# Documentation



Every architectural change requires:



\- ADR

\- Documentation update

\- Engineering review



Documentation is part of the Definition of Done.

