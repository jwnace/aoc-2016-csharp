using aoc_2016_csharp.Day21;

namespace aoc_2016_csharp_tests;

public class Day21Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "gfdhebac";
        var actual = Day21.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "dhaegfbc";
        var actual = Day21.Part2();
        actual.Should().Be(expected);
    }
}
