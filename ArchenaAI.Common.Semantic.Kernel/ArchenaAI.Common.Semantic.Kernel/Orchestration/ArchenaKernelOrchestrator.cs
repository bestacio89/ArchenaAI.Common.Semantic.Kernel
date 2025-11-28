using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ArchenaAI.Common.Semantic.Kernel.Skills;
using ArchenaAI.Common.Semantic.Kernel.Memory.Contracts;

namespace ArchenaAI.Common.Semantic.Kernel.Orchestration
{
    /// <summary>
    /// High-level orchestrator implementing reasoning, reflection, planning,
    /// and memory-augmented loops, while broadcasting semantic events
    /// via the distributed SemanticOrchestrator.
    /// </summary>
    public sealed class ArchenaKernelOrchestrator
    {
        private readonly IArchenaKernel _kernel;
        private readonly IMemoryManager _memory;
        private readonly ISkillRegistry _skills;
        private readonly SemanticOrchestrator _semanticBus;

        public ArchenaKernelOrchestrator(
            IArchenaKernel kernel,
            IMemoryManager memory,
            ISkillRegistry skills,
            SemanticOrchestrator semanticBus)
        {
            _kernel = kernel;
            _memory = memory;
            _skills = skills;
            _semanticBus = semanticBus;
        }

        // ------------------------------------------------------------
        // Main reasoning loop
        // ------------------------------------------------------------
        public async Task<string> RunReasoningLoopAsync(
            string input,
            LoopOptions options,
            CancellationToken ct = default)
        {
            string current = input;
            string? last = null;

            // Emit initial event
            await _semanticBus.EmitReasoningEventAsync(
                skill: "reasoning.start",
                content: current,
                ct);

            for (int i = 0; i < options.MaxIterations; i++)
            {
                // Memory retrieval
                if (options.UseMemory)
                {
                    var memories = await _memory.SearchAsync(current, 3, ct);
                    var context = string.Join("\n", memories.Select(m => m.Content));

                    if (!string.IsNullOrWhiteSpace(context))
                        current = $"Context:\n{context}\n\nUser Input:\n{current}";
                }

                // Emit event: reasoning-pass
                await _semanticBus.EmitReasoningEventAsync(
                    skill: "reasoning.pass",
                    content: current,
                    ct);

                // Execute reasoning step
                string reasoning = await _kernel.ExecuteSkillAsync("reasoning", current, ct);

                // Emit event: reasoning-output
                await _semanticBus.EmitReasoningEventAsync(
                    skill: "reasoning.output",
                    content: reasoning,
                    ct);

                // Reflection step
                if (options.UseReflection)
                {
                    string reflection = await _kernel.ExecuteSkillAsync("reflection", reasoning, ct);

                    await _semanticBus.EmitReasoningEventAsync(
                        skill: "reflection",
                        content: reflection,
                        ct);

                    reasoning = reflection;
                }

                // Correction step
                if (options.UseCorrection)
                {
                    string correction = await _kernel.ExecuteSkillAsync("correction", reasoning, ct);

                    await _semanticBus.EmitReasoningEventAsync(
                        skill: "correction",
                        content: correction,
                        ct);

                    reasoning = correction;
                }

                // Termination criteria
                if (ShouldTerminate(reasoning, options))
                {
                    await _semanticBus.EmitReasoningEventAsync(
                        skill: "reasoning.finish",
                        content: reasoning,
                        ct);

                    return reasoning;
                }

                if (reasoning == last)
                {
                    await _semanticBus.EmitReasoningEventAsync(
                        skill: "reasoning.stalled",
                        content: reasoning,
                        ct);

                    return reasoning;
                }

                last = reasoning;
                current = reasoning;
            }

            await _semanticBus.EmitReasoningEventAsync(
                skill: "reasoning.max_iterations",
                content: last ?? input,
                ct);

            return last ?? input;
        }

        // ------------------------------------------------------------
        // Planning loop (Plan → Execute → Summarize)
        // ------------------------------------------------------------
        public async Task<string> RunPlanExecuteLoopAsync(
            string input,
            LoopOptions options,
            CancellationToken ct = default)
        {
            // Plan
            string plan = await _kernel.ExecuteSkillAsync("planning", input, ct);

            await _semanticBus.EmitReasoningEventAsync("planning", plan, ct);

            // Execute plan steps
            string result = await RunReasoningLoopAsync(plan, options, ct);

            // Summarize
            string summary = await _kernel.ExecuteSkillAsync("summarization", result, ct);

            await _semanticBus.EmitReasoningEventAsync("summarization", summary, ct);

            return summary;
        }

        private bool ShouldTerminate(string output, LoopOptions opt)
        {
            if (string.IsNullOrWhiteSpace(output))
                return true;

            if (opt.TerminationRegex != null &&
                Regex.IsMatch(output, opt.TerminationRegex, RegexOptions.IgnoreCase))
                return true;

            return false;
        }
    }
}
