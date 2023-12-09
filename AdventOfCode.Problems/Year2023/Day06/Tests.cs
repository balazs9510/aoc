using Xunit;

namespace AdventOfCode.Problems.Year2023.Day06;

public class Tests
{
    [Fact]
    public void ParseTest()
    {
        var sol = new Solution();
        sol.Part1(false);
    }

    [Fact]
    public void Part1ExampleTest()
    {
        var sol = new Solution();
        var res = sol.Part1(true);

        Assert.Equal(288, res);
    }

    [Fact]
    public void Part1Test()
    {
        var sol = new Solution();
        var res = sol.Part1(false);

        Assert.Equal(588588, res);
    }

    [Theory]
    [InlineData(true, 71503)]
    [InlineData(false, 34655848)]
    public void Part2(bool exmaple, long expected)
    {
        var res = new Solution().Part2(exmaple);
        Assert.Equal(expected, res);
    }
}
