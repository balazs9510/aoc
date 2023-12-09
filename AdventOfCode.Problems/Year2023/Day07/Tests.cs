using Xunit;

namespace AdventOfCode.Problems.Year2023.Day07;

public class Tests
{

    [Theory]
    [InlineData(true, 6440)]
    [InlineData(false, 245794640)]
    public void Part1(bool exmaple, long expected)
    {
        var res = new Solution().Part1(exmaple);
        Assert.Equal(expected, res);
    }

    [Theory]
    [InlineData(true, 71503)]
    [InlineData(false, 34655848)]
    public void Part2(bool exmaple, long expected)
    {
        var res = new Solution().Part2(exmaple);
        Assert.Equal(expected, res);
    }

    [Theory]
    [InlineData("22222", Combination.OAK5)]
    [InlineData("22223", Combination.OAK4)]
    [InlineData("33344", Combination.FH)]
    [InlineData("T55J5", Combination.OAK3)]
    [InlineData("QQQJA", Combination.OAK3)]
    [InlineData("KK677", Combination.Pair2)]
    [InlineData("KTJJT", Combination.Pair2)]
    [InlineData("32T3K", Combination.Pair)]
    [InlineData("23456", Combination.HH)]
    public void CombinationTests(string handS, Combination expected)
    {
        var hand = new Hand(handS);

        Assert.Equal(expected, hand.Combination);
    }

    [Theory]
    [InlineData("KK677", "KTJJT")]
    [InlineData("QQQJA", "T55J5")]
    [InlineData("QQQJA", "KTJJT")]
    public void HandCompareTest(string handS1, string handS2)
    {
        var hand1 = new Hand(handS1);
        var hand2 = new Hand(handS2);

        var result = hand1.CompareTo(hand2);

        Assert.Equal(1, result);
    }
}
