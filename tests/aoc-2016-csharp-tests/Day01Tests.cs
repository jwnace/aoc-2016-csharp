using aoc_2016_csharp.Day01;

namespace aoc_2016_csharp_tests;

public class Day01Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 300;
        var actual = Day01.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 159;
        var actual = Day01.Part2();
        actual.Should().Be(expected);
    }
}
