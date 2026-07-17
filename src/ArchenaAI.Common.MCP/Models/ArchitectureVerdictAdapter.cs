using Aegis.Shared.Architecture.Enums;
using Aegis.Shared.Architecture.Models;
using ArchenaAI.Common.MCP.Abstractions;

public sealed class ArchitectureVerdictAdapter : IVerdict
{
    private readonly ArchitectureEvaluatorResult _result;
    private readonly ArchitectureRuleSeverity _denyThreshold;

    public ArchitectureVerdictAdapter(
        ArchitectureEvaluatorResult result,
        ArchitectureRuleSeverity denyThreshold)
    {
        _result = result;
        _denyThreshold = denyThreshold;
    }

    public bool IsAllowed =>
        !_result.RuleResults.Any(r => r.Severity >= _denyThreshold);

    public ArchitectureRuleSeverity MaxSeverity =>
        _result.RuleResults.Any()
            ? _result.RuleResults.Max(r => r.Severity)
            : ArchitectureRuleSeverity.Info;

    public IReadOnlyCollection<string> ViolatedRuleIds =>
        _result.RuleResults.Select(r => r.RuleId).ToArray();
}
