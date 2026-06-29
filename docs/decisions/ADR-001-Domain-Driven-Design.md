\# ADR-001: Domain Model Drives the Application



\## Status



Accepted



\## Context



GarageAI is an AI-first Garage Management Platform.



The system will support:



\- Garage operations

\- AI Receptionist

\- Tool Calling

\- LangGraph

\- RAG

\- Voice AI



The business will continue to evolve over time.



\## Decision



The application will be designed around the business domain.



The database will persist the domain model.



The database will not define the domain.



Business logic belongs in the Domain and Application layers.



The AI interacts with APIs and tools only.



The AI never accesses SQL Server directly.



\## Consequences



Benefits



\- Easier to evolve

\- Better separation of concerns

\- Supports AI orchestration

\- Cleaner architecture

\- Easier testing



Trade-offs



\- More upfront design

\- More abstraction

\- Requires discipline

