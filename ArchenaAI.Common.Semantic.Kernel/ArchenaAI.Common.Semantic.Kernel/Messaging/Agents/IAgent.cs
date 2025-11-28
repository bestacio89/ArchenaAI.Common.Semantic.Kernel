using System.Threading;
using System.Threading.Tasks;

namespace ArchenaAI.Common.Semantic.Kernel.Messaging.Agents
{
    public interface IAgent
    {
        string Name { get; }

        Task HandleAsync(AgentEnvelope envelope, CancellationToken ct);
    }
}
