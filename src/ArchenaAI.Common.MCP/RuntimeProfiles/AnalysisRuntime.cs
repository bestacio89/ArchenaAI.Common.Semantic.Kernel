using Aegis.Shared.Architecture.Enums;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.RuntimeProfiles
{
    public static class AnalysisRuntime
    {
        public static readonly McpRuntimeProfile Instance =
            new()
            {
                Name = "AnalysisRuntime",

                EnabledRuleIds = new[]
                {
                    // Architecture
                    "AEG-ARCH-*",

                    // Dependency
                    "AEG-DEP-*",

                    // Contracts / Naming
                    "AEG-NAME-*",

                    // Security
                    "AEG-SEC-AUTH001",
                    "AEG-SEC-SECRET001"
                },

                Budget = ExecutionBudget.ReadOnly(),

                AllowedCapabilities = new[]
                {
                    Capabilities.ReadRepository(),
                    Capabilities.ReadMetadata(),
                    Capabilities.InspectArchitecture()
                },

                DenyThreshold = ArchitectureRuleSeverity.Critical
            };
    }
}
