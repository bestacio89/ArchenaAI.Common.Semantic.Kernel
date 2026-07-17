using Aegis.Shared.Architecture.Models;
using ArchenaAI.Common.MCP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.MCP.Tribunals
{
    public static class RuntimeEvaluatorResult
    {
        public static ArchitectureEvaluatorResult ForAction(RuntimeActionDescriptor action)
            => new(
                source: "MCP.RuntimeTribunal",
                target: action.ActionId,
                domain: "Runtime"
            )
            {
                Category = "Execution",
                Layer = action.OriginLayer
            };
    }

}
