using aoc_2016_csharp.Day24;


namespace aoc_2016_csharp_tests;

public class Day24Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 448;
        var actual = Day24.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 672;
        var actual = Day24.Part2();
        actual.Should().Be(expected);
    }
}
