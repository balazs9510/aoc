using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdventOfCode.Problems.Year2023.Day08;

public class Solution : SolutionBase
{
    public int Part1(bool exmaple)
    {
        string instructions;
        int stepCount;
        Dictionary<string, Node> dict;
        ParseToDict(exmaple, out instructions, out stepCount, out dict);

        var current = dict["AAA"];
        while (current.name != "ZZZ")
        {
            var currentInstruction = instructions[stepCount % instructions.Length];
            current = currentInstruction == 'L' ? dict[current.left] : dict[current.right];
            stepCount++;
        }

        return stepCount;
    }

    private void ParseToDict(bool exmaple, out string instructions, out int stepCount, out Dictionary<string, Node> dict)
    {
        var lines = GetInputLines(exmaple);
        instructions = lines[0];
        string pattern = @"(\w+)\s*=\s*\(([^,]+),\s*([^)]+)\)";
        stepCount = 0;
        dict = new Dictionary<string, Node>();
        for (int i = 2; i < lines.Length; i++)
        {
            Match match = Regex.Match(lines[i], pattern);
            var name = match.Groups[1].Value.Trim();
            dict.Add(name, new Node(name, match.Groups[2].Value.Trim(), match.Groups[3].Value.Trim()));
        }
    }

    public long Part2(bool exmaple)
    {
        var lines = GetInputLines(exmaple);
        string pattern = @"(\w+)\s*=\s*\(([^,]+),\s*([^)]+)\)";
        string instructions = lines[0];
        long stepCount = 0;
        Dictionary<string, Node> dict = new Dictionary<string, Node>();
        List<long> walkLengths = new();

        for (int i = 2; i < lines.Length; i++)
        {
            Match match = Regex.Match(lines[i], pattern);
            var name = match.Groups[1].Value.Trim();
            dict.Add(name, new Node(name, match.Groups[2].Value.Trim(), match.Groups[3].Value.Trim()));
        }

        var currents = dict.Keys.Where(x => x.EndsWith('A'));
        foreach (var n in currents)
        {
            long steps = 0;
            var curNode = n;

            while (true)
            {
                if (curNode.EndsWith('Z')) break;

                if (instructions[(int)steps % instructions.Length] == 'L') curNode = dict[curNode].left;
                else curNode = dict[curNode].right;
                steps++;
            }
            walkLengths.Add(steps);
        }
        return walkLengths.Aggregate(1L, (lcm, next) => FindLCM(lcm, next));
    }

    public static double FindGCD(double a, double b)
    {
        if (a == 0 || b == 0) return Math.Max(a, b);
        return (a % b == 0) ? b : FindGCD(b, a % b);
    }

    public static double FindLCM(double a, double b) => a * b / FindGCD(a, b);
    public static long FindLCM(long a, long b) => a * b / FindGCD(a, b);

    public static long FindGCD(long a, long b)
    {
        if (a == 0 || b == 0) return Math.Max(a, b);
        return (a % b == 0) ? b : FindGCD(b, a % b);
    }
}



public class Node
{
    public Node(string name, string left, string right)
    {
        this.name = name;
        this.left = left;
        this.right = right;
    }

    public string name { get; set; }
    public string left { get; set; }
    public string right { get; set; }
    // Update the position of the node based on the new node
    public void UpdatePosition(Node newNode)
    {
        this.name = newNode.name;
        left = newNode.left;
        right = newNode.right;
    }
}