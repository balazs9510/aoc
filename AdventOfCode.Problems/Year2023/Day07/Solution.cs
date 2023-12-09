namespace AdventOfCode.Problems.Year2023.Day07;

public class Solution : SolutionBase
{
    public int Part1(bool exmaple)
    {
        var lines = GetInputLines(exmaple);

        var players = lines.Select(line => new Player(line)).ToList();
        
        players.Sort();
        var sum = 0;
        for (int i = 0; i < players.Count; i++)
        {
            sum += (i + 1) * players[i].Bid;
        }
        return sum;
    }

    public long Part2(bool exmaple)
    {
        return 0;
    }
}

public class Player : IComparable<Player>
{
    public int Bid { get; set; }
    public Hand Hand { get; set; }

    public Player(string data)
    {
        var split = data.Split(' ');
        Bid = int.Parse(split[1]);
        Hand = new Hand(split[0]);
    }

    public int CompareTo(Player? other)
    {
        return Hand.CompareTo(other!.Hand);
    }

    public override string ToString()
    {
        return new string(Hand.Cards.ToArray());
    }
}

public class Hand : IComparable<Hand>
{
    public List<char> Cards { get; set; } = new List<char>();
    private Combination? combination;

    public Combination Combination
    {
        get { if (combination is null) combination = GetCombination(); return combination.Value; }
    }

    public Hand(string cards)
    {
        Cards = cards.ToCharArray().ToList();
    }

    private Combination GetCombination()
    {
        var cardDict = new Dictionary<char, int>();

        foreach (var card in Cards)
        {
            if (cardDict.ContainsKey(card))
            {
                cardDict[card]++;
            }
            else
            {
                cardDict.Add(card, 1);
            }
        }

        if (cardDict.ContainsKey('J'))
        {
            var value = cardDict['J'];
            cardDict.Remove('J');

            if (cardDict.Count == 0)
            {
                cardDict.Add('J', 5);
            }
            else
            {
                var max = cardDict.Values.Max();
                var keys = cardDict.Keys;

                foreach (var key in keys)
                {
                    if (cardDict[key] == max)
                    {
                        cardDict[key] += value;
                        break;
                    }
                }
            }          
        }

        if (cardDict.Values.Count == 1) return Combination.OAK5;
        if (cardDict.Values.Any(x => x == 4)) return Combination.OAK4;
        if (cardDict.Values.Count == 2) return Combination.FH;
        if (cardDict.Values.Any(x => x == 3)) return Combination.OAK3;
        if (cardDict.Values.Count == 3) return Combination.Pair2;
        if (cardDict.Values.Count == 4) return Combination.Pair;

        return Combination.HH;
    }

    public int CompareTo(Hand other)
    {
        if (Combination < other.Combination)
        {
            return 1;
        }

        if (Combination > other.Combination)
        {
            return -1;
        }

        var cardCompaprer = new CardComparer();

        for (int i = 0; i < Cards.Count; i++)
        {
            var res = cardCompaprer.Compare(Cards[i], other.Cards[i]);
            if (res != 0) return res;
        }
        return 0;
    }
}

public class CardComparer : IComparer<char>
{
    public int Compare(char x, char y)
    {
        var mX = Map[x]; var mY = Map[y];
        if (mX > mY)
            return 1;
        if (mX < mY)
            return -1;
        else
            return 0;
    }

    private static Dictionary<char, int> Map => new Dictionary<char, int>
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'J', 1 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
    };
}

public enum Combination
{
    OAK5,
    OAK4,
    FH,
    OAK3,
    Pair2,
    Pair,
    HH,
}