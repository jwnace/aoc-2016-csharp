using aoc_2016_csharp.Day15;

namespace aoc_2016_csharp_tests;

public class Day15Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 203_660;
        var actual = Day15.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 2_408_135;
        var actual = Day15.Part2();
        actual.Should().Be(expected);
    }
}
