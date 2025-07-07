
namespace SkillSystem.Bll.DesignPatternServices;

public class ForeachLoopOddSumStrategy : IOddSumStrategy
{
    public int CalculateSum(IEnumerable<int> numbers)
    {
        var sumOdd = 0;
        foreach (var number in numbers)
        {
            if(number % 2 != 0)
                sumOdd += number;
        }
        
        return sumOdd;
    }
}
