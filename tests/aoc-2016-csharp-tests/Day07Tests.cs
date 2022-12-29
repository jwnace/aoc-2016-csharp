using aoc_2016_csharp.Day07;

namespace aoc_2016_csharp_tests;

public class Day07Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 115;
        var actual = Day07.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 231;
        var actual = Day07.Part2();
        actual.Should().Be(expected);
    }
}
