using aoc_2016_csharp.Day05;

namespace aoc_2016_csharp_tests;

public class Day05Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "1a3099aa";
        var actual = Day05.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "694190cd";
        var actual = Day05.Part2();
        actual.Should().Be(expected);
    }
}
