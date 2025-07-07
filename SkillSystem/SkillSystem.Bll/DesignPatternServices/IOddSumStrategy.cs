namespace SkillSystem.Bll.DesignPatternServices;

public interface IOddSumStrategy
{
    int CalculateSum(IEnumerable<int> numbers);
}

