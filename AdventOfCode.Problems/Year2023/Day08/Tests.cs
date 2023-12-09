using Xunit;

namespace AdventOfCode.Problems.Year2023.Day08;

public class Tests
{

    [Theory]
    [InlineData(true, 6)]
    [InlineData(false, 24253)]
    public void Part1(bool exmaple, long expected)
    {
        var res = new Solution().Part1(exmaple);
        Assert.Equal(expected, res);
    }

    [Theory]
    [InlineData(true, 6)]
    [InlineData(false, 12357789728873)]
    public void Part2(bool exmaple, long expected)
    {
        var res = new Solution().Part2(exmaple);
        Assert.Equal(expected, res);
    }
}
