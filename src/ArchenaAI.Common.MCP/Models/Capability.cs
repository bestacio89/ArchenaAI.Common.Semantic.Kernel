using ArchenaAI.Common.MCP.Abstractions;
using ArchenaAI.Common.MCP.Models.ArchenaAI.Common.MCP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.MCP.Models
{
    public sealed record Capability : ICapability
    {
        public string Id { get; init; }
        public string Description { get; init; }
        public CapabilityScope Scope { get; init; }
        public CapabilityConstraints Constraints { get; init; }
    }

}
