# **ArchenaAI.SemanticKernel**

### *Deterministic Skill-Based AI Engine for .NET 10, built on Franz.Common*

**ArchenaAI.SemanticKernel** is the *core execution layer* of the ArchenaAI framework.
It provides a **Semantic Kernel–style abstraction**, but built with:

* **Deterministic execution**
* **Franz.Common pipelines**
* **Typed skills**
* **Event-driven orchestration (Kafka)**
* **Memory-aware context**
* **Model-agnostic execution (OpenAI/Azure/Open-source)**

This module is responsible for:

* Skill definitions
* Skill invocation
* Skill metadata/descriptor system
* Execution context
* Memory hooks
* Event connectors
* Planner foundation (if applicable inside this module)
* Kernel builder and runtime

This is **NOT** the entire ArchenaAI framework — only the “Kernel Layer” used internally and by hosted runtimes.

---

# 🚀 **What This Module Does**

### ✔ **Skill System**

Defines and registers executable skills with metadata, descriptors, and typed inputs/outputs.

### ✔ **Skill Invocation Engine**

Handles deterministic execution through Franz pipelines (logging, caching, resilience, telemetry).

### ✔ **Skill Context**

Wraps user input, memory hooks, session state, and system policies.

### ✔ **Connectors**

Kafka-based messaging connectors (publish/subscribe) used as semantic kernel “skills” or building blocks.

### ✔ **Kernel Builder**

Provides a clean API to build a runtime with:

* Registered skills
* Model providers
* Memory providers
* Event connectors
* Execution policies

---

# 📦 **Getting Started**

### Install Franz and dependencies:

```bash
dotnet add package Franz.Common --version 1.6.21
dotnet add package Franz.Common.Messaging.Kafka --version 1.6.21
```

### Clone this module:

```bash
git clone https://github.com/<your-org>/ArchenaAI
cd src/ArchenaAI.SemanticKernel
```

### Build:

```bash
dotnet build -c Release
```

---

# 📘 **Core Concepts**

ArchenaAI.SemanticKernel provides:

---

## 🧠 **1. Skills**

Skills are first-class units of work, similar to Semantic Kernel plugins but deterministic and typed.

```csharp
public class SummarizeSkill : ISkill
{
    public Task<SkillResult> ExecuteAsync(SkillContext context, CancellationToken ct);
}
```

### Skill Metadata

Each skill has:

* Name
* Description
* Input schema
* Output schema
* Execution policy
* Allowed models
* Tags/categories

---

## 📜 **2. Skill Descriptor**

Encapsulates metadata used by:

* Registry
* Planner (if used)
* Skill browser
* Host runtime

---

## 🧩 **3. Skill Registry**

Automatically discovers and loads:

* Local skills
* Model-based skills
* Event-driven skills
* HTTP/refit-based skills
* Kafka connectors

This allows the kernel to dynamically choose capabilities.

---

## 🔄 **4. Connectors (Kafka, HTTP, Messaging)**

The SemanticKernel includes **event-driven connectors** that SK does not have:

* **KafkaConnector** (publish/subscribe)
* **HTTP Client/Refit-based connectors**
* **Domain event skills**

Kafka usage example:

```csharp
await kafka.PublishAsync("topic", payload, ct);
```

This enables multi-agent behavior, workflows, and asynchronous computation.

---

## 🧠 **5. Memory (Hooks Only in This Module)**

This module defines the **interfaces and hooks** that upper layers implement:

* Semantic memory
* Vector embedding providers
* Long-term storage
* Session memory

This ensures the Kernel is *memory-aware* but *not memory-dependent*.

---

## 🏗️ **6. Kernel Builder**

Used to construct a runtime instance:

```csharp
var kernel = KernelBuilder.Create()
    .WithSkillsFromAssembly(typeof(SomeSkill))
    .WithKafka(options)
    .WithModelProvider(openAiProvider)
    .Build();
```

This mirrors Semantic Kernel but with Franz-level determinism.

---

# 🔧 **Build & Test**

Build kernel:

```bash
dotnet build src/ArchenaAI.SemanticKernel -c Release
```

Run tests:

```bash
dotnet test tests/ArchenaAI.SemanticKernel.Tests
```

---

# 🤝 **Contributing**

Yes, contributions are welcome!
This module accepts:

* New skills
* New connectors
* Memory providers
* Model adapters
* Skill browser tools
* Refactoring and documentation improvements

See root-level CONTRIBUTING.md for details.

---

# 🗺️ **Roadmap for This Module**

This module’s roadmap is separate from the full ArchenaAI framework:

### **v0.3 – Skill System baseline**

* Full `SkillDescriptor`
* Auto-discovery
* Unified invocation

### **v0.4 – Connectors Pack**

* Kafka skills
* HTTP/refit skill adapters

### **v0.5 – Memory Interfaces**

* Embedding provider
* Memory provider abstraction
* Vector retrieval interface

### **v0.6 – Planner Foundation**

* Intent → Skill routing
* Basic step generation

### **v0.7 – Kernel Host**

* Hosting layer
* Configuration system
* Runtime pipeline

---

# 📄 License

MIT License — same as Franz ecosystem.

---

# 💬 Questions?

Open an issue or discussion on GitHub.


