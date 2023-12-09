
using Xunit;

namespace AdventOfCode.Problems.Year2023.Day05;

public class Tests
{
    [Fact]
    public void ParseTest()
    {
        var sol = new Solution();
        sol.Part1(true);
    }

    [Fact]
    public void Part1ExmpleTest()
    {
        var sol = new Solution();
        var res = sol.Part1(true);
        Assert.Equal(35, res);
    }

    [Fact]
    public void Part1Test()
    {
        var sol = new Solution();
        var res = sol.Part1(false);
        Assert.Equal(806029445, res);
    }

    [Fact]
    public void Part2ExmpleTest()
    {
        var sol = new Solution();
        var res = sol.Part2(true);
        Assert.Equal(46, res);
    }

    [Fact]
    public void Part2Test()
    {
        var sol = new Solution();
        var res = sol.Part2(false);
        Assert.Equal(46, res);
    }
}
