using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.MCP.Models
{
    public sealed record Evidence
    {
        public string PolicyId { get; init; }
        public string Summary { get; init; }
        public string MetricKey { get; init; }
        public object ObservedValue { get; init; }
    }

}
