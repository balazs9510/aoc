namespace AdventOfCode.Problems;

public class SolutionBase
{
    protected string[] GetInputLines(bool example)
    {
        var day = GetType().Namespace!.Replace("AdventOfCode.Problems.", "").Replace(".", "/");

        var lines = File.ReadAllLines($"{day}/inputs/input.txt");
        if (example)
        {
            lines = File.ReadAllLines($"{day}/inputs/example.txt");
        }
        return lines;
    }
}
