using aoc_2016_csharp.Day13;

namespace aoc_2016_csharp_tests;

public class Day13Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 82;
        var actual = Day13.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 138;
        var actual = Day13.Part2();
        actual.Should().Be(expected);
    }
}
