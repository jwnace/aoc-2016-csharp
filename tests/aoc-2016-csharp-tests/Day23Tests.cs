using aoc_2016_csharp.Day23;

namespace aoc_2016_csharp_tests;

public class Day23Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 14_160;
        var actual = Day23.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 479_010_720;
        var actual = Day23.Part2();
        actual.Should().Be(expected);
    }
}
