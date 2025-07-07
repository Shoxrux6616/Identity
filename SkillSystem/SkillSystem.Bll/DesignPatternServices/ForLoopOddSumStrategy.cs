
namespace SkillSystem.Bll.DesignPatternServices;

public class ForLoopOddSumStrategy : IOddSumStrategy
{
    public int CalculateSum(IEnumerable<int> numbers)
    {
        var oddSum = 0;
        var numbersList = numbers.ToList();
        for(var i = 0; i < numbers.Count(); i++)
        {
            if (numbersList[i] % 2 != 0)
            {
                oddSum += numbersList[i];
            }
        }

        return oddSum;
    }
}
