using Aegis.Shared.Architecture.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.MCP.Abstractions
{
    public interface IVerdict
    {
        bool IsAllowed { get; }
        ArchitectureRuleSeverity MaxSeverity { get; }
        IReadOnlyCollection<string> ViolatedRuleIds { get; }
    }

}
