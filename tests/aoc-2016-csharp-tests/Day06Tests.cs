using aoc_2016_csharp.Day06;

namespace aoc_2016_csharp_tests;

public class Day06Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "mshjnduc";
        var actual = Day06.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "apfeeebz";
        var actual = Day06.Part2();
        actual.Should().Be(expected);
    }
}
