namespace AdventOfCode.Problems.Year2023.Day06;

public class Solution : SolutionBase
{

    public int Part1(bool exmaple)
    {
        var races = Parse(exmaple);
        var multi = 1;
        foreach (var race in races)
        {
            var count = 0;
            for (int i = 0; i < race.time; i++)
            {
                var speed = i;
                var remaining = race.time - i;
                var distance = remaining * speed;
                if (distance > race.distance)
                {
                    count++;
                }
            }
            multi *= count;
        }

        return multi;
    }

    public long Part2(bool exmaple)
    {
        var lines = GetInputLines(exmaple);
        var time = long.Parse(lines[0].Replace("Time:", "").Replace(" ", ""));
        var distance = long.Parse(lines[1].Replace("Distance:", "").Replace(" ", ""));
        long count = 0;
        for (int i = 0; i < time; i++)
        {
            var speed = i;
            var remaining = time - i;
            var dist = remaining * speed;
            if (dist > distance)
            {
                count++;
            }
        }

        return count;
    }

    private List<Race> Parse(bool exmaple)
    {
        var lines = GetInputLines(exmaple);
        var times = lines[0].Replace("Time:", "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var distances = lines[1].Replace("Distance:", "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var races = new List<Race>();
        for (int i = 0; i < times.Count; i++)
        {
            races.Add(new Race(times[i], distances[i]));
        }
        return races;
    }
}

public record Race(int time, int distance);
