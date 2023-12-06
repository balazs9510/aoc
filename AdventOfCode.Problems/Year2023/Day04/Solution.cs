using Xunit;

namespace AdventOfCode.Problems.Year2023.Day04;

public class Solution
{
    public double Part1(bool example)
    {
        var lines = GetInputLines(example);

        return lines.Select(x => (new Card(x)).CalculatePoints()).Sum();
    }

    public int Part2(bool example)
    {
        var lines = GetInputLines(example);
        var cards = lines.Select(x => new Card(x)).OrderBy(c => c.No);
        var countDictionary = cards.ToDictionary(x => x.No, y => 1);

        for (var i = 1; i < countDictionary.Count; i++)
        {
            var card = cards.First(x => x.No == i);
            var cardCount = countDictionary[i];
            var winningCount = card.GetWinningCount();
            var wonCards = Enumerable.Range(i + 1, winningCount);
            foreach (var wC in wonCards)
            {
                if (countDictionary.ContainsKey(wC))
                {
                    countDictionary[wC] += cardCount;
                }
                else
                {
                    Assert.True(wC >= countDictionary.Count);
                }
            }
        }

        return countDictionary.Select(x => x.Value).Sum();
    }

    private string[] GetInputLines(bool example)
    {
        var lines = File.ReadAllLines("Year2023/Day04/input.txt");
        if (example)
        {
            lines = File.ReadAllLines("Year2023/Day04/example.txt");
        }
        return lines;
    }
}

