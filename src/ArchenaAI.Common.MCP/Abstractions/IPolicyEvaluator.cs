using Aegis.Shared.Architecture.Enums;
using Aegis.Shared.Architecture.Models;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.Abstractions
{
    public interface IPolicyEvaluator
    {
        string RuleId { get; }
        ArchitectureRuleSeverity Severity { get; }

        void Evaluate(
            RuntimeActionDescriptor action,
            AuthorityToken authority,
            ExecutionBudget budget,
            ArchitectureEvaluatorResult result);
    }
}
