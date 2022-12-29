using aoc_2016_csharp.Day04;

namespace aoc_2016_csharp_tests;

public class Day04Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 278_221;
        var actual = Day04.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 267;
        var actual = Day04.Part2();
        actual.Should().Be(expected);
    }
}
