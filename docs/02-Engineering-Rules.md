\# GarageAI Engineering Rules



Version: 1.0

Status: Approved

Owner: GarageAI Engineering Team



\---



\# Purpose



This document defines the engineering principles used to build GarageAI.



These rules are intended to ensure consistency, maintainability, and long-term scalability.



Technology changes.



Engineering principles remain.



\---



\# Rule 1 — Business Before Technology



Business requirements drive architecture.



Technology exists to support the business.



Never introduce a framework or pattern without a business or engineering reason.



\---



\# Rule 2 — Capabilities Before Providers



GarageAI is designed around business capabilities.



Examples:



\- Conversation

\- Knowledge

\- Vision

\- Voice

\- Automation



Never design around technology vendors such as OpenAI or Azure OpenAI.



\---



\# Rule 3 — The AI Orchestrator is the AI Gateway



Every AI interaction must pass through the AI Orchestrator.



The Orchestrator owns the AI workflow.



Business features never communicate directly with AI providers.



\---



\# Rule 4 — Providers are Infrastructure



AI providers are implementation details.



Examples:



\- OpenAI

\- Azure OpenAI

\- Ollama



Application must never reference provider SDKs.



\---



\# Rule 5 — Vertical Slice First



Every business feature owns:



\- Commands

\- Queries

\- Handlers

\- Models



Features should remain independent.



Avoid shared business logic unless there is a clear reason.



\---



\# Rule 6 — Clean Architecture



Dependencies always point inward.



Business logic must remain independent from:



\- Databases

\- AI providers

\- User interfaces

\- Frameworks



\---



\# Rule 7 — Constructor Injection Only



Dependencies are supplied by the Composition Root.



Business classes never construct infrastructure dependencies.



Avoid using "new" for external services inside business logic.



\---



\# Rule 8 — Official Documentation First



When integrating third-party libraries:



\- Read official documentation.

\- Verify SDK version.

\- Understand the object model.



Never implement based solely on memory or blog posts.



\---



\# Rule 9 — Architecture is Frozen During a Sprint



Architecture is not redesigned while implementing a sprint.



New ideas are recorded in the backlog.



Architecture changes are reviewed separately.



\---



\# Rule 10 — Evidence Before Architecture Changes



Every architectural proposal must answer:



1\. What problem are we solving?

2\. What evidence supports the change?

3\. What alternatives were considered?

4\. What are the trade-offs?

5\. Why is the change necessary now?



Architecture evolves because of evidence, not opinion.



\---



\# Rule 11 — Evolutionary Architecture



Build for today's requirements.



Leave room for tomorrow's growth.



Avoid premature abstractions.



Add complexity only when it solves a real problem.



\---



\# Rule 12 — Single Responsibility



Every class should have one clear responsibility.



Responsibilities should be easy to explain in one sentence.



\---



\# Rule 13 — Naming



Use business language.



Good:



\- Conversation

\- Booking

\- Customer



Avoid technology-driven names.



Examples:



\- ChatManager

\- OpenAIBookingService

\- AIRepository



\---



\# Rule 14 — Simplicity Before Abstraction



Do not introduce abstractions until they solve a real problem.



Every abstraction must earn its existence.



\---



\# Rule 15 — Code Reviews



Every implementation should answer:



\- Is it understandable?

\- Is it testable?

\- Is it maintainable?

\- Does it follow our architecture?

\- Can another engineer understand it in six months?



\---



\# Rule 16 — Learning Mindset



Every new technology must be understood before it is implemented.



The objective is not only to build software.



The objective is to become a better engineer.



\---



\# Definition of Done



A feature is complete when:



\- Code compiles.

\- Tests pass (where applicable).

\- Documentation is updated.

\- Architecture remains consistent.

\- No unnecessary complexity has been introduced.



\---



\# Engineering Philosophy



GarageAI is built to demonstrate professional software engineering.



Every architectural decision should be explainable, justified, and maintainable.



When in doubt, choose the simplest solution that satisfies today's requirements while allowing future evolution.

