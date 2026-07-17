namespace ArchenaAI.Common.MCP.Models
{
    public sealed record CapabilityConstraints
    {
        // 🔐 Structural constraints
        public IReadOnlyCollection<string>? AllowedDomains { get; init; }
        public IReadOnlyCollection<string>? AllowedLayers { get; init; }

        // ⏱ Execution constraints
        public int? MaxUsages { get; init; }
        public TimeSpan? MaxExecutionTime { get; init; }

        // 💾 Persistence constraints
        public bool RequiresTransaction { get; init; }
        public bool AllowsWrite { get; init; }

        // 🔁 Behavioral constraints
        public bool AllowsCrossDomain { get; init; }
        public bool AllowsBlockingIO { get; init; }

        // 🧠 AI / governance constraints
        public bool RequiresHumanApproval { get; init; }
        public bool IsDelegable { get; init; }
    }
}
