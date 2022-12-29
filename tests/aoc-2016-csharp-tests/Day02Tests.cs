using aoc_2016_csharp.Day02;

namespace aoc_2016_csharp_tests;

public class Day02Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "35749";
        var actual = Day02.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "9365C";
        var actual = Day02.Part2();
        actual.Should().Be(expected);
    }
}
