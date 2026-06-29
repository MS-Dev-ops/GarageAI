\# AI Platform



Version: 1.0

Status: Approved

Owner: GarageAI Engineering Team



\---



\# Purpose



This document describes the architecture of the GarageAI Artificial Intelligence Platform.



The AI Platform is designed to be reusable, provider-independent, and capable of evolving as new AI capabilities are introduced.



The platform supports today's requirements while allowing future expansion without major architectural redesign.



\---



\# Design Philosophy



GarageAI is not built around OpenAI.



GarageAI is built around business capabilities.



AI providers are replaceable implementation details.



The platform owns the AI workflow.



\---



\# Core Principle



Every AI request flows through the AI Orchestrator.



```

Business Feature

&#x20;       │

&#x20;       ▼

AI Orchestrator

&#x20;       │

&#x20;       ▼

AI Provider

&#x20;       │

&#x20;       ▼

Language Model

```



The AI Orchestrator is the single gateway into the AI platform.



\---



\# Business Capabilities



The platform currently defines the following capabilities.



```

AI



├── Conversation

├── Knowledge

├── Voice

├── Vision

└── Automation

```



These capabilities belong to the business.



They are independent from technology providers.



\---



\# AI Orchestrator



The AI Orchestrator coordinates the complete AI workflow.



Responsibilities include:



\- Executing AI requests

\- Selecting the appropriate provider

\- Managing conversation flow

\- Supporting future tool execution

\- Supporting future memory

\- Supporting future provider selection



The Orchestrator owns workflow.



Providers do not.



\---



\# AI Providers



Providers are infrastructure implementations.



Examples include:



\- OpenAI

\- Azure OpenAI

\- Ollama



Providers should only communicate with AI models.



Providers must never contain business logic.



\---



\# Current AI Workflow



Version 1 of GarageAI supports a simple AI conversation.



```

User



↓



Conversation



↓



AskConversationQueryHandler



↓



IAIOrchestrator



↓



AIOrchestrator



↓



OpenAI SDK



↓



GPT Model



↓



Response

```



This workflow intentionally remains simple.



\---



\# Future Evolution



The AI Platform is designed to evolve without changing business features.



Future versions may introduce:



\## Tool Calling



```

Conversation



↓



AI Orchestrator



↓



LLM



↓



Tool Request



↓



Booking Tool



↓



LLM



↓



Response

```



\---



\## Memory



Conversation history may be introduced to provide contextual responses.



The Orchestrator will own memory integration.



\---



\## Knowledge (RAG)



Future versions will support Retrieval-Augmented Generation.



Knowledge sources may include:



\- Company documentation

\- Service manuals

\- Policies

\- Frequently Asked Questions



\---



\## Voice



Voice capability will support:



Speech to Text



Text to Speech



Real-time voice conversations



\---



\## Vision



Vision capability will support:



Vehicle inspection



Image understanding



Damage assessment



Document analysis



\---



\# Architectural Principles



The AI Platform follows these principles:



\- Business before technology

\- Capability-driven design

\- Provider independence

\- Evolutionary architecture

\- Single AI Gateway

\- Vertical Slice Architecture

\- Clean Architecture



\---



\# Current Limitations



Version 1 intentionally excludes:



\- Tool Calling

\- Memory

\- Streaming

\- Multi-provider routing

\- AI Agents

\- RAG



These capabilities will be introduced only when justified by business requirements.



\---



\# Long-Term Goal



GarageAI should become a reusable enterprise AI platform.



Business domains should be replaceable.



The AI Platform should remain reusable across multiple industries.



\---



\# References



\- 00-Vision.md

\- 01-Architecture.md

\- 02-Engineering-Rules.md

