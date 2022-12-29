using aoc_2016_csharp.Day10;

namespace aoc_2016_csharp_tests;

public class Day10Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "161";
        var actual = Day10.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 133_163;
        var actual = Day10.Part2();
        actual.Should().Be(expected);
    }
}
