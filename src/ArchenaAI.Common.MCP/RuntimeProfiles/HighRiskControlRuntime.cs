using Aegis.Shared.Architecture.Enums;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.RuntimeProfiles
{
    public static class HighRiskControlledRuntime
    {
        public static readonly McpRuntimeProfile Instance =
            new()
            {
                Name = "HighRiskControlledRuntime",

                EnabledRuleIds = new[]
                {
                    "AEG-ARCH-*",
                    "AEG-PERSIST-*",
                    "AEG-SEC-*",
                    "AEG-PERF-*"
                },

                Budget = ExecutionBudget.Migration(),

                AllowedCapabilities = new[]
                {
                    Capabilities.DbWriteTransactional(),
                    Capabilities.ModifySchema(),
                    Capabilities.EmitAuditEvents()
                },

                DenyThreshold = ArchitectureRuleSeverity.Blocker
            };
    }
}
