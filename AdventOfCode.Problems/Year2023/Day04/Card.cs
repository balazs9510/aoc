namespace AdventOfCode.Problems.Year2023.Day04;

public class Card
{
    public int No { get; set; }
    public List<int> WinningNumbers { get; set; } = new List<int>();
    public List<int> PlayerNumbers { get; set; } = new List<int>();

    public Card() { }

    // Format: Card {Id}: [n1 n2 ... ] | [m1 m2 ...]
    public Card(string line)
    {
        var cSplit = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
        No = int.Parse(cSplit[0].Replace("Card ", ""));
        var nSplit = cSplit[1].Split('|', StringSplitOptions.RemoveEmptyEntries);

        WinningNumbers = nSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        PlayerNumbers = nSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }

    public double CalculatePoints()
    {
        var count = GetWinningCount();
        return count == 0 ? 0 : Math.Pow(2, count - 1);
    }

    public int GetWinningCount()
    {
        var count = 0;
        foreach (var winningNumber in WinningNumbers)
        {
            if (PlayerNumbers.Exists(n => n == winningNumber))
            {
                count++;
            }
        }

        return count;
    }
}

