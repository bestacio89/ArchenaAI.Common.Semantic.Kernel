using Aegis.Shared.Architecture.Enums;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.RuntimeProfiles
{
    public static class PersistenceGovernedRuntime
    {
        public static readonly McpRuntimeProfile Instance =
            new()
            {
                Name = "PersistenceGovernedRuntime",

                EnabledRuleIds = new[]
                {
                    "AEG-PERSIST-*",
                    "AEG-SEC-*",
                    "AEG-PERF-EXEC001"
                },

                Budget = ExecutionBudget.Persistence(),

                AllowedCapabilities = new[]
                {
                    Capabilities.DbRead(),
                    Capabilities.DbWriteTransactional()
                },

                DenyThreshold = ArchitectureRuleSeverity.Critical
            };
    }
}
