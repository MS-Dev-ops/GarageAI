\# GarageAI Architecture



Version: 1.0

Status: Approved

Owner: GarageAI Engineering Team



\---



\# Overview



GarageAI is designed as an enterprise AI platform using proven architectural principles.



The objective is to build a system that is:



\- Maintainable

\- Testable

\- Scalable

\- Provider Independent

\- Business Driven



\---



\# Architectural Principles



GarageAI is built using:



\- Domain Driven Design (DDD)

\- Vertical Slice Architecture

\- CQRS

\- Clean Architecture

\- SOLID Principles

\- Evolutionary Architecture



Each principle exists because it solves a business or engineering problem.



Patterns are never introduced simply because they are popular.



\---



\# Solution Structure



```



GarageAI



├── docs

├── src

│

├── GarageAI.Api

├── GarageAI.Application

├── GarageAI.Domain

├── GarageAI.Infrastructure

├── GarageAI.Web

│

├── tests

│

└── GarageAI.sln



```



\---



\# Layer Responsibilities



\## Domain



Owns business rules.



Contains:



\- Entities

\- Value Objects

\- Domain Events

\- Business Behaviour



The Domain must not depend on any other project.



\---



\## Application



Owns business use cases.



Contains:



\- Commands

\- Queries

\- Handlers

\- Contracts

\- Interfaces



Application never depends on Infrastructure.



Application never references external SDKs.



\---



\## Infrastructure



Owns technology implementations.



Contains:



\- Entity Framework

\- OpenAI SDK

\- Azure SDK

\- Repositories

\- External APIs



Infrastructure implements contracts defined by Application.



\---



\## API



Provides HTTP endpoints.



Responsibilities:



\- Receive requests

\- Validate input

\- Execute use cases

\- Return responses



No business logic.



\---



\## Web



Presentation layer.



Responsible only for user interaction.



Business logic belongs in Application.



\---



\# Dependency Rule



Dependencies always point inward.



```



Web

↓



API

↓



Application

↓



Domain



Infrastructure

↓



Application



```



The Domain never depends on Infrastructure.



\---



\# AI Architecture



The AI platform follows an orchestrator-centric design.



```



Conversation



↓



AI Orchestrator



↓



AI Provider



↓



LLM



```



Application communicates only with the AI Orchestrator contract.



Infrastructure contains the implementation.



\---



\# Vertical Slice



Every feature owns its own models.



Example:



```



Bookings



Queries

GetBookings



Commands

CreateBooking



AI



Conversation

Ask



```



Features should be independent whenever possible.



\---



\# CQRS



Queries return data.



Commands change state.



The separation improves maintainability and scalability.



\---



\# Clean Architecture



Business logic is independent from:



\- Databases

\- AI Providers

\- Frameworks

\- User Interface



Technology can change without changing business logic.



\---



\# Evolutionary Architecture



Architecture evolves only when justified.



Changes require:



\- Problem

\- Evidence

\- Trade-offs

\- Alternatives

\- Decision



No architectural change is made based on preference alone.



\---



\# Naming Principles



Name software using business language.



Examples:



Good



\- Conversation

\- Booking

\- Customer

\- Vehicle



Avoid technology-driven names.



Examples:



\- OpenAIBookingService

\- ChatRepository

\- AIManager



Business language always comes first.



\---



\# Architectural Goal



GarageAI should remain understandable after years of development.



New capabilities should extend the platform without requiring major redesign.



