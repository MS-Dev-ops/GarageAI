\# ADR-001 – AI Platform is Orchestrator-Centric



Status: Accepted



Date: 2026-06-29



\---



\# Context



GarageAI is designed to support Artificial Intelligence across multiple business capabilities.



Future requirements include:



\- Conversation

\- Tool Calling

\- Memory

\- Voice

\- Vision

\- Knowledge (RAG)

\- Multiple AI Providers



The architecture required a central point responsible for coordinating AI workflows.



\---



\# Problem



If business features communicate directly with AI providers:



\- Business logic becomes coupled to provider SDKs.

\- Tool execution becomes fragmented.

\- Conversation management becomes inconsistent.

\- Future AI capabilities become difficult to introduce.



\---



\# Decision



Introduce an AI Orchestrator.



The AI Orchestrator becomes the single gateway into the AI platform.



Business features communicate only with the Orchestrator.



Providers communicate only with AI models.



\---



\# Responsibilities



The AI Orchestrator owns:



\- AI workflow

\- Conversation flow

\- Future provider selection

\- Future tool execution

\- Future memory integration



The AI Orchestrator does NOT own business logic.



\---



\# Consequences



Positive



\- Centralised AI workflow

\- Provider independence

\- Easier future evolution

\- Consistent architecture



Negative



\- One additional abstraction



The additional abstraction is considered acceptable because future AI capabilities require orchestration.



\---



\# Alternatives Considered



\## Direct OpenAI Calls



Rejected.



Reason:



Business features would become coupled to the OpenAI SDK.



\---



\## Chat Service



Rejected.



Reason:



The design centred around technology instead of AI workflow.



\---



\## Provider-Centric Architecture



Rejected.



Reason:



Providers should remain implementation details.



Business capabilities should not depend on providers.



\---



\# Decision Drivers



\- Clean Architecture

\- DDD

\- Vertical Slice

\- Evolutionary Architecture

\- Future AI capabilities



\---



\# References



\- 00-Vision.md

\- 01-Architecture.md

\- 02-Engineering-Rules.md

\- 03-AI-Platform.md

