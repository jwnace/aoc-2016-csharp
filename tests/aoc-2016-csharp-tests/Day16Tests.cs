using aoc_2016_csharp.Day16;
using FluentAssertions;

namespace aoc_2016_csharp_tests;

public class Day16Tests
{
    [TestCase("1", "100")]
    [TestCase("0", "001")]
    [TestCase("11111", "11111000000")]
    [TestCase("111100001010", "1111000010100101011110000")]
    public void ExpandDataTest(string input, string expected)
    {
        // act
        var actual = Day16.ExpandData(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("110010110100", "100")]
    public void GetChecksumTest(string input, string expected)
    {
        // act
        var actual = Day16.GetChecksum(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }
}
