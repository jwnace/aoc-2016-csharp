using aoc_2016_csharp.Day12;

namespace aoc_2016_csharp_tests;

public class Day12Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 318_007;
        var actual = Day12.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 9_227_661;
        var actual = Day12.Part2();
        actual.Should().Be(expected);
    }
}
