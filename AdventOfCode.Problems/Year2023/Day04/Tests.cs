using Xunit;

namespace AdventOfCode.Problems.Year2023.Day04
{
    public class Day04Tests
    {
        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 41, 48, 83, 86, 17 }, new int[] { 83, 86, 6, 31, 17, 9, 48, 53 }, 1)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 13, 32, 20, 16, 61 }, new int[] { 61, 30, 68, 82, 17, 32, 24, 19 }, 2)]
        public void CardParsingTest(string input, int[] winning, int[] player, int cardNo)
        {
            // Arrange 
            // Act
            var card = new Card(input);

            // Assert
            Assert.Equal(cardNo, card.No);
            Assert.Equal(winning.Length, card.WinningNumbers.Count);
            Assert.Equal(player.Length, card.PlayerNumbers.Count);

            for (int i = 0; i < winning.Length; i++)
            {
                Assert.Equal(winning[i], card.WinningNumbers[i]);
            }

            for (int i = 0; i < player.Length; i++)
            {
                Assert.Equal(player[i], card.PlayerNumbers[i]);
            }
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
        public void CardPointTest(string input, int expected)
        {
            // Arrange 
            // Act
            var card = new Card(input);

            // Assert
            Assert.Equal(expected, card.CalculatePoints());
        }

        [Fact]
        public void Part1ExampleTest()
        {
            // Arrange
            // Act
            var result = (new Solution()).Part1(true);

            // Assert
            Assert.Equal(13, result);
        }

        [Fact]
        public void Part1Test()
        {
            // Arrange
            // Act
            var result = (new Solution()).Part1(false);

            // Assert
            Assert.Equal(21558, result);
        }

        [Fact]
        public void Part2ExampleTest()
        {
            // Arrange
            // Act
            var result = (new Solution()).Part2(true);

            // Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void Part2Test()
        {
            // Arrange
            // Act
            var result = (new Solution()).Part2(false);

            // Assert
            Assert.Equal(10425665, result);
        }
    }
}
