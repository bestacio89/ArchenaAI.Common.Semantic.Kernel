using ArchenaAI.Common.MCP.Models.ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.Models
{
    public static class Capabilities
    {
        // ───────────── ARCHITECTURE / READ ─────────────

        public static Capability ReadRepository() =>
            new()
            {
                Id = "repo.read",
                Description = "Read source code and repository structure",
                Scope = CapabilityScope.Read,
                Constraints = new CapabilityConstraints
                {
                    AllowsWrite = false,
                    AllowedDomains = new[] { "Architecture" }
                }
            };

        public static Capability ReadMetadata() =>
            new()
            {
                Id = "metadata.read",
                Description = "Read architectural and system metadata",
                Scope = CapabilityScope.Read,
                Constraints = new CapabilityConstraints
                {
                    AllowsWrite = false
                }
            };

        public static Capability InspectArchitecture() =>
            new()
            {
                Id = "architecture.inspect",
                Description = "Inspect architectural structure and boundaries",
                Scope = CapabilityScope.Read,
                Constraints = new CapabilityConstraints
                {
                    AllowsWrite = false,
                    AllowedDomains = new[] { "Architecture" }
                }
            };

        // ───────────── ARCHITECTURE / GOVERNANCE ─────────────

        public static Capability GenerateCodeArtifacts() =>
            new()
            {
                Id = "code.generate",
                Description = "Generate code artifacts without executing them",
                Scope = CapabilityScope.Write,
                Constraints = new CapabilityConstraints
                {
                    AllowsWrite = true,
                    RequiresHumanApproval = false,
                    IsDelegable = false
                }
            };

        public static Capability ProposeRefactorings() =>
            new()
            {
                Id = "architecture.refactor.propose",
                Description = "Propose architectural refactorings",
                Scope = CapabilityScope.Write,
                Constraints = new CapabilityConstraints
                {
                    AllowsWrite = false,
                    IsDelegable = true
                }
            };

        // ───────────── EXECUTION ─────────────

        public static Capability CallInternalServices() =>
            new()
            {
                Id = "service.call.internal",
                Description = "Invoke internal services",
                Scope = CapabilityScope.Execute,
                Constraints = new CapabilityConstraints
                {
                    AllowsCrossDomain = false,
                    IsDelegable = false
                }
            };

        public static Capability EmitEvents() =>
            new()
            {
                Id = "event.emit",
                Description = "Emit internal domain events",
                Scope = CapabilityScope.Emit,
                Constraints = new CapabilityConstraints
                {
                    AllowsCrossDomain = false,
                    IsDelegable = true
                }
            };

        // ───────────── PERSISTENCE ─────────────

        public static Capability DbRead() =>
            new()
            {
                Id = "db.read",
                Description = "Read from persistent storage",
                Scope = CapabilityScope.Read,
                Constraints = new CapabilityConstraints
                {
                    AllowedDomains = new[] { "Persistence" }
                }
            };

        public static Capability DbWriteTransactional() =>
            new()
            {
                Id = "db.write.transactional",
                Description = "Write to persistent storage inside a mandatory transaction",
                Scope = CapabilityScope.Write,
                Constraints = new CapabilityConstraints
                {
                    RequiresTransaction = true,
                    AllowsWrite = true,
                    MaxUsages = 1,
                    AllowedDomains = new[] { "Persistence" },
                    IsDelegable = false
                }
            };

        public static Capability ModifySchema() =>
            new()
            {
                Id = "db.schema.modify",
                Description = "Modify database schema (DDL, migrations)",
                Scope = CapabilityScope.Modify,
                Constraints = new CapabilityConstraints
                {
                    RequiresTransaction = true,
                    RequiresHumanApproval = true,
                    MaxUsages = 1,
                    AllowedLayers = new[] { "Infrastructure" },
                    IsDelegable = false
                }
            };

        // ───────────── GOVERNANCE / AUDIT ─────────────

        public static Capability EmitAuditEvents() =>
            new()
            {
                Id = "audit.emit",
                Description = "Emit audit and compliance events",
                Scope = CapabilityScope.Emit,
                Constraints = new CapabilityConstraints
                {
                    AllowsCrossDomain = true,
                    IsDelegable = true
                }
            };
    }
}
