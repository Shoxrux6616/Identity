
namespace SkillSystem.Bll.DesignPatternServices;

public class LinqOddSumStrategy : IOddSumStrategy
{
    public int CalculateSum(IEnumerable<int> numbers)
    {
        var res = numbers.Where(x => x % 2 != 0).Sum();
        return res;
    }
}