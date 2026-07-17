using Aegis.Shared.Architecture.Models;
using Aegis.Shared.Architecture.Enums;
using ArchenaAI.Common.MCP.Abstractions;
using ArchenaAI.Common.MCP.Models;

namespace ArchenaAI.Common.MCP.Tribunals
{
    public abstract class RuntimeTribunalBase
    {
        protected abstract IEnumerable<IPolicyEvaluator> Policies { get; }

        public ArchitectureEvaluatorResult Evaluate(
            RuntimeActionDescriptor action,
            AuthorityToken authority,
            McpRuntimeProfile runtimeProfile)
        {
            var result = new ArchitectureEvaluatorResult(
                source: "MCP.RuntimeTribunal",
                target: action.ActionId,
                domain: "Runtime")
            {
                Category = runtimeProfile.Name,
                Layer = action.OriginLayer
            };

            foreach (var policy in Policies)
            {
                // 🔒 Rule gating by profile
                if (!runtimeProfile.EnabledRuleIds.Any(id =>
                        id.EndsWith("*")
                            ? policy.RuleId.StartsWith(id.TrimEnd('*'))
                            : policy.RuleId == id))
                    continue;

                policy.Evaluate(
                    action,
                    authority,
                    runtimeProfile.Budget,
                    result);

                // 🚨 Constitutional stop
                if (result.RuleResults.Any(r =>
                        r.Severity >= runtimeProfile.DenyThreshold))
                {
                    break;
                }
            }

            return result;
        }
    }
}
