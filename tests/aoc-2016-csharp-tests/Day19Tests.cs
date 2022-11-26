using aoc_2016_csharp.Day19;
using FluentAssertions;

namespace aoc_2016_csharp_tests;

public class Day19Tests
{
    [TestCase(5, 3)]
    public void SolvePart1Test(int input, int expected)
    {
        // act
        var actual = Day19.SolvePart1(input);

        // assert
        actual.Should().Be(expected);
    }

    [TestCase(5, 2)]
    public void SolvePart2Test(int input, int expected)
    {
        // act
        var actual = Day19.SolvePart2(input);

        // assert
        actual.Should().Be(expected);
    }
}
