using System;
using System.Collections.Generic;
using System.Text;

namespace ArchenaAI.Common.Semantic.Kernel
{
    public interface IArchenaKernel
    {
        Task<string> ThinkAsync(string input, CancellationToken ct);
        Task<string> ExecuteSkillAsync(string skillName, string input, CancellationToken ct);
    }
   
}
