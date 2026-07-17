using Aegis.Shared.Architecture.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.MCP.Models
{
    public sealed class McpRuntimeProfile
    {
        public string Name { get; init; }

        public IReadOnlyCollection<string> EnabledRuleIds { get; init; }
        public ExecutionBudget Budget { get; init; }
        public IReadOnlyCollection<Capability> AllowedCapabilities { get; init; }

        public ArchitectureRuleSeverity DenyThreshold { get; init; }
    }

}
