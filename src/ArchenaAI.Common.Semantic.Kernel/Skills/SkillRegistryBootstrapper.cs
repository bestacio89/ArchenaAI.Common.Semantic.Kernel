using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ArchenaAI.Common.Semantic.Kernel.Skills;

public sealed class SkillRegistryBootstrapper
{
    private readonly IServiceCollection _services;

    public SkillRegistryBootstrapper(IServiceCollection services)
    {
        _services = services;
    }

    public void RegisterFromAssembly(Assembly assembly)
    {
        var skillTypes = assembly
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                typeof(IArchenaSkill).IsAssignableFrom(t)
            );

        foreach (var skillType in skillTypes)
        {
            // Register for DI
            _services.AddScoped(typeof(IArchenaSkill), skillType);

            // Also optional: register concrete type directly 
            _services.AddScoped(skillType);
        }
    }
}
