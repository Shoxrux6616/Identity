namespace SkillSystem.Bll.DesignPatternServices;

public class OddSumContext
{
    private readonly IOddSumStrategy _strategy;

    public OddSumContext(OddSumStrategyResolver resolver)
    {
        _strategy = resolver.ResolveStrategy();
    }

    public int ExecuteStrategy(IEnumerable<int> numbers)
    {
        return _strategy.CalculateSum(numbers);
    }
}
