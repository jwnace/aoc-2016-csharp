using aoc_2016_csharp.Day14;

namespace aoc_2016_csharp_tests;

public class Day14Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 23_769;
        var actual = Day14.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 20_606;
        var actual = Day14.Part2();
        actual.Should().Be(expected);
    }
}
