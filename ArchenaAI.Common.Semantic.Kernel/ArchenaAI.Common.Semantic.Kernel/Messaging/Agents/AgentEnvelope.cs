using System;
using System.Collections.Generic;

namespace ArchenaAI.Common.Semantic.Kernel.Messaging.Agents
{
    public sealed class AgentEnvelope
    {
        public string Type { get; set; } = AgentMessageType.Request;
        public string Agent { get; set; } = string.Empty;
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
        public string? ReplyTo { get; set; }

        public string Payload { get; set; } = string.Empty;

        public Dictionary<string, object?> Metadata { get; set; }
            = new(StringComparer.OrdinalIgnoreCase);
    }
}
