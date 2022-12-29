using aoc_2016_csharp.Day11;

namespace aoc_2016_csharp_tests;

public class Day11Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 33;
        var actual = Day11.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 57;
        var actual = Day11.Part2();
        actual.Should().Be(expected);
    }
}
