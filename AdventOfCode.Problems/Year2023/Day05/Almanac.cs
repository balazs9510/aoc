using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace AdventOfCode.Problems.Year2023.Day05;

public class Almanac
{
    public List<long> Seeds { get; set; } = new List<long>();
    public List<RangeMap> SeedRanges { get; set; } = new List<RangeMap>();
    public List<RangeMap> SeedToSoil { get; set; } = new List<RangeMap>();
    public List<RangeMap> SoilToFertilizer { get; set; } = new List<RangeMap>();
    public List<RangeMap> FertilizerToWater { get; set; } = new List<RangeMap>();
    public List<RangeMap> WaterToLight { get; set; } = new List<RangeMap>();
    public List<RangeMap> LightToTemperature { get; set; } = new List<RangeMap>();
    public List<RangeMap> TemperatureToHummidity { get; set; } = new List<RangeMap>();
    public List<RangeMap> HummidityToLocation { get; set; } = new List<RangeMap>();

    public List<AlmanacEntry> Entries { get; set; } = new List<AlmanacEntry>();

    public Almanac(string[] lines)
    {
        Seeds = lines[0].Replace("seeds: ", "").Split(' ').Select(long.Parse).ToList();
        for (int i = 0; i < Seeds.Count; i += 2)
        {
            SeedRanges.Add(new RangeMap { SourceStart = Seeds[i], DestStart = Seeds[i + 1] });
        }

        List<RangeMap> currentMap = null;

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            if (!char.IsDigit(line[0]))
            {
                var newEntry = new AlmanacEntry();
                Entries.Add(newEntry);
                currentMap = GetMap(line);
            }
            else
            {
                var split = line.Split(' ').Select(long.Parse).ToList();
                var range = new RangeMap
                {
                    SourceStart = split[1],
                    DestStart = split[0],
                    RangeLength = split[2],
                };
                currentMap!.Add(range);
                Entries[Entries.Count - 1].Ranges.Add(range);
            }
        }

        Entries.ForEach(e => e.Order());
    }

    public long GetMappedValueForSeed(long seed)
    {
        seed = GetMappedValue(SeedToSoil, seed);
        seed = GetMappedValue(SoilToFertilizer, seed);
        seed = GetMappedValue(FertilizerToWater, seed);
        seed = GetMappedValue(WaterToLight, seed);
        seed = GetMappedValue(LightToTemperature, seed);
        seed = GetMappedValue(TemperatureToHummidity, seed);
        seed = GetMappedValue(HummidityToLocation, seed);

        return seed;
    }

    public long Part2()
    {

        foreach (var range in Entries.First().Ranges)
        {

        }

        return 0;
    }
    private long GetRevesredMappedValue(List<RangeMap> ranges, long value)
    {
        foreach (var range in ranges.OrderBy(x => x.DestStart))
        {
            if (range.DestStart <= value && value <= range.DestEnd)
            {
                return range.SourceStart + value - range.DestStart;
            }
        }
        return value;
    }

    private long GetMappedValue(List<RangeMap> ranges, long value)
    {
        if (ranges[0].SourceStart > value || ranges[ranges.Count - 1].SourceEnd < value) return value;
        foreach (var range in ranges)
        {
            if (range.SourceStart <= value && value <= range.SourceEnd)
            {
                return range.DestStart + value - range.SourceStart;
            }
        }
        return value;
    }

    private List<RangeMap> GetMap(string line)
    {
        var start = line.Substring(0, 4);
        switch (start)
        {
            case "seed": return SeedToSoil;
            case "soil": return SoilToFertilizer;
            case "fert": return FertilizerToWater;
            case "wate": return WaterToLight;
            case "ligh": return LightToTemperature;
            case "temp": return TemperatureToHummidity;
            case "humi": return HummidityToLocation;
            default: throw new Exception("nono");
        }
    }
}

public class AlmanacEntry
{
    public List<RangeMap> Ranges { get; set; } = new List<RangeMap>();

    public void Order()
    {
        Ranges = Ranges.OrderBy(x => x.SourceStart).ToList();
    }
}

public class RangeMap
{
    public long SourceStart { get; set; }
    public long DestStart { get; set; }
    public long RangeLength { get; set; }

    public long SourceEnd => SourceStart + RangeLength - 1;
    public long DestEnd => DestStart + RangeLength - 1;
}