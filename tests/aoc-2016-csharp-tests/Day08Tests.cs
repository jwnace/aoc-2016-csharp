using aoc_2016_csharp.Day08;

namespace aoc_2016_csharp_tests;

public class Day08Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 110;
        var actual = Day08.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "ZJHRKCPLYJ";
        var actual = Day08.Part2();
        actual.Should().Be(expected);
    }
}
