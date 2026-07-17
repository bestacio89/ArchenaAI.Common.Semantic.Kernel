using ArchenaAI.Common.MCP.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.MCP.Models
{
    public sealed record RuntimeActionDescriptor : IRuntimeActionDescriptor
    {
        public string ActionId { get; init; }           // "repo.read", "db.write"
        public string OriginComponent { get; init; }    // Kernel / Runtime / Agent
        public string TargetComponent { get; init; }    // DB / FS / API
        public string OriginLayer { get; init; }        // Api / App / Domain / Infra
        public string TargetLayer { get; init; }
        public string CapabilityId { get; init; }
        public IReadOnlySet<string> ResponsibilityDomains { get; init; }
        public ExecutionContext Context { get; init; }
    }


}
