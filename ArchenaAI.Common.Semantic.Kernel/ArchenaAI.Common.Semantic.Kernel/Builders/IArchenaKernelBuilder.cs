using ArchenaAI.Common.Semantic.Kernel.Connectors.LLM;
using ArchenaAI.Common.Semantic.Kernel.Memory.Contracts;
using ArchenaAI.Common.Semantic.Kernel.Skills;

namespace ArchenaAI.Common.Semantic.Kernel.Builders
{
    public interface IArchenaKernelBuilder
    {
        IArchenaKernelBuilder UseConnector<TConnector>() where TConnector : ILLMConnector;
        IArchenaKernelBuilder UseMemory<TMemory>() where TMemory : IMemoryProvider;
        IArchenaKernelBuilder RegisterSkill<TSkill>() where TSkill : IArchenaSkill;
        IArchenaKernel Build();
    }
}
