\# ADR-002 – Application Owns Contracts, Infrastructure Owns Implementations



Status: Accepted



Date: 2026-06-29



\---



\# Context



GarageAI follows Clean Architecture.



Artificial Intelligence requires communication with external providers such as:



\- OpenAI

\- Azure OpenAI

\- Ollama



Business features should remain independent from external technologies.



\---



\# Problem



If Application references external SDKs:



\- Business logic becomes coupled to providers.

\- AI providers cannot be replaced easily.

\- Unit testing becomes more difficult.

\- Architecture boundaries become unclear.



\---



\# Decision



Application owns contracts.



Infrastructure owns implementations.



Example:



Application



\- IAIOrchestrator



Infrastructure



\- AIOrchestrator



The implementation is free to use:



\- OpenAI SDK

\- Azure SDK

\- HTTP

\- Databases



Application never references these technologies.



\---



\# Dependency Direction



```

Application



↓



IAIOrchestrator



↑



Infrastructure



↓



AIOrchestrator



↓



OpenAI SDK

```



Dependencies always point toward the Application.



\---



\# Responsibilities



\## Application



Owns:



\- Business use cases

\- Contracts

\- Requests

\- Responses

\- Commands

\- Queries

\- Handlers



Application does not know:



\- OpenAI

\- Azure OpenAI

\- HTTP

\- Databases

\- Entity Framework



\---



\## Infrastructure



Owns:



\- SDKs

\- Databases

\- HTTP

\- External APIs

\- Provider implementations



Infrastructure implements contracts defined by Application.



\---



\# Decision Drivers



\- Clean Architecture

\- Dependency Inversion Principle

\- Testability

\- Provider Independence



\---



\# Alternatives Considered



\## Place AIOrchestrator inside Application



Rejected.



Reason:



The implementation depends on external SDKs.



\---



\## Place contracts inside Infrastructure



Rejected.



Reason:



Business logic should define required capabilities.



Technology should implement them.



\---



\# Consequences



Positive



\- Clear project boundaries

\- Easier testing

\- Replaceable providers

\- Stable business layer



Negative



\- One additional project dependency



The trade-off is considered acceptable.



\---



\# Engineering Rule



When deciding where a class belongs, ask:



"If I remove the OpenAI SDK, can this class still compile?"



If YES



→ Application



If NO



→ Infrastructure



\---



\# References



\- 01-Architecture.md

\- 02-Engineering-Rules.md

\- ADR-001-Orchestrator-Centric-AI.md

