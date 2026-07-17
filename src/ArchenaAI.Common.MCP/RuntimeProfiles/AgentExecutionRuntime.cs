using Aegis.Shared.Architecture.Enums;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.RuntimeProfiles
{
    public static class AgentExecutionRuntime
    {
        public static readonly McpRuntimeProfile Instance =
            new()
            {
                Name = "AgentExecutionRuntime",

                EnabledRuleIds = new[]
                {
                    "AEG-ARCH-*",
                    "AEG-DES-*",
                    "AEG-DEP-*",
                    "AEG-PERF-*",
                    "AEG-SEC-*"
                },

                Budget = ExecutionBudget.Agent(),

                AllowedCapabilities = new[]
                {
                    Capabilities.ReadRepository(),
                    Capabilities.CallInternalServices(),
                    Capabilities.EmitEvents()
                },

                DenyThreshold = ArchitectureRuleSeverity.Critical
            };
    }
}
