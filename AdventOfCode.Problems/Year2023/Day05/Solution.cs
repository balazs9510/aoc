using AdventOfCode.Problems.Year2023.Day04;
using Xunit;

namespace AdventOfCode.Problems.Year2023.Day05;

public class Solution
{
    private static object locky = new object();

    public double Part1(bool example)
    {
        var lines = GetInputLines(example);
        var almanac = new Almanac(lines);
        foreach (var seed in almanac.Seeds)
        {
            var mapped = almanac.GetMappedValueForSeed(seed);
        }
        return almanac.Seeds.Select(almanac.GetMappedValueForSeed).Min();
    }

    public long Part2(bool example)
    {
        var lines = GetInputLines(example);
        var almanac = new Almanac(lines);

        var min = long.MaxValue;
        Parallel.ForEach(almanac.SeedRanges, (range) =>
        {
            for (var i = range.SourceStart; i < range.SourceStart + range.DestStart; i++)
            {
                var percent = 100 * (((decimal)i - range.SourceStart) / range.DestStart);
                var mapped = almanac.GetMappedValueForSeed(i);
                if (mapped < min)
                {
                    lock (locky)
                    {
                        if (mapped < min)
                            min = mapped;
                    }
                }
            }
        });
        //min = almanac.Part2();
        return min;
    }



    private string[] GetInputLines(bool example)
    {
        var lines = File.ReadAllLines("Year2023/Day05/inputs/input.txt");
        if (example)
        {
            lines = File.ReadAllLines("Year2023/Day05/inputs/example.txt");
        }
        return lines;
    }
}

