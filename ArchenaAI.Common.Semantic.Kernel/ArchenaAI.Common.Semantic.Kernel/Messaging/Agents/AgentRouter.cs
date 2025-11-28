using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ArchenaAI.Common.Semantic.Kernel.Messaging.Agents
{
    public sealed class AgentRouter
    {
        private readonly ConcurrentDictionary<string, IAgent> _agents = new();
        private readonly ILogger<AgentRouter> _logger;

        public AgentRouter(ILogger<AgentRouter> logger)
        {
            _logger = logger;
        }

        public void RegisterAgent(IAgent agent)
        {
            _agents[agent.Name] = agent;
        }

        public async Task RouteAsync(AgentEnvelope envelope, CancellationToken ct)
        {
            if (!_agents.TryGetValue(envelope.Agent, out var agent))
            {
                _logger.LogError("No agent registered with name: {Agent}", envelope.Agent);
                return;
            }

            await agent.HandleAsync(envelope, ct);
        }
    }
}
