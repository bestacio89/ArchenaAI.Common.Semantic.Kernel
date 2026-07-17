using Aegis.Shared.Architecture.Enums;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.RuntimeProfiles
{
    public static class ArchitectureGovernanceRuntime
    {
        public static readonly McpRuntimeProfile Instance =
            new()
            {
                Name = "ArchitectureGovernanceRuntime",

                EnabledRuleIds = new[]
                {
                    "AEG-ARCH-*",
                    "AEG-DES-*",
                    "AEG-DEP-*"
                },

                Budget = ExecutionBudget.Architecture(),

                AllowedCapabilities = new[]
                {
                    Capabilities.ReadRepository(),
                    Capabilities.GenerateCodeArtifacts(),
                    Capabilities.ProposeRefactorings()
                },

                DenyThreshold = ArchitectureRuleSeverity.Critical
            };
    }
}
