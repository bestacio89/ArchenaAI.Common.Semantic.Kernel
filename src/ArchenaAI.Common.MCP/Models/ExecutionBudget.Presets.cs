namespace ArchenaAI.Common.MCP.Models
{
    public sealed partial record ExecutionBudget
    {
        // ───────────── READ-ONLY / ANALYSIS ─────────────
        public static ExecutionBudget ReadOnly() =>
            new()
            {
                MaxReasoningSteps = 200,
                MaxToolCalls = 10,
                MaxExecutionTime = TimeSpan.FromSeconds(30),
                MaxCostUnits = 100
            };

        // ───────────── ARCHITECTURE GOVERNANCE ─────────────
        public static ExecutionBudget Architecture() =>
            new()
            {
                MaxReasoningSteps = 500,
                MaxToolCalls = 25,
                MaxExecutionTime = TimeSpan.FromMinutes(2),
                MaxCostUnits = 300
            };

        // ───────────── AGENT EXECUTION (BOUNDED) ─────────────
        public static ExecutionBudget Agent() =>
            new()
            {
                MaxReasoningSteps = 300,
                MaxToolCalls = 15,
                MaxExecutionTime = TimeSpan.FromMinutes(1),
                MaxCostUnits = 200
            };

        // ───────────── PERSISTENCE (TRANSACTIONAL) ─────────────
        public static ExecutionBudget Persistence() =>
            new()
            {
                MaxReasoningSteps = 150,
                MaxToolCalls = 5,
                MaxExecutionTime = TimeSpan.FromSeconds(20),
                MaxCostUnits = 150
            };

        // ───────────── HIGH-RISK / MIGRATION ─────────────
        public static ExecutionBudget Migration() =>
            new()
            {
                MaxReasoningSteps = 1000,
                MaxToolCalls = 50,
                MaxExecutionTime = TimeSpan.FromMinutes(10),
                MaxCostUnits = 1000
            };
    }
}
