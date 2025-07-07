using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillSystem.Bll.DesignPatternServices;

public class OddSumStrategyResolver
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DesignPatternSettings DesignPatternSettings;

    public OddSumStrategyResolver(IServiceProvider serviceProvider, DesignPatternSettings designPatternSettings)
    {
        _serviceProvider = serviceProvider;
        DesignPatternSettings = designPatternSettings;
    }

    public IOddSumStrategy ResolveStrategy()
    {
        var strategyName = DesignPatternSettings.StrategyType;

        return strategyName switch
        {
            "for" => _serviceProvider.GetRequiredService<ForLoopOddSumStrategy>(),
            "foreach" => _serviceProvider.GetRequiredService<ForeachLoopOddSumStrategy>(),
            "linq" => _serviceProvider.GetRequiredService<LinqOddSumStrategy>(),
            _ => throw new InvalidOperationException("Invalid strategy configured")
        };
    }
}
