using aoc_2016_csharp.Day16;

namespace aoc_2016_csharp_tests;

public class Day16Tests
{
    [TestCase("1", "100")]
    [TestCase("0", "001")]
    [TestCase("11111", "11111000000")]
    [TestCase("111100001010", "1111000010100101011110000")]
    public void ExpandDataTest(string input, string expected)
    {
        var actual = Day16.ExpandData(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("110010110100", "100")]
    public void GetChecksumTest(string input, string expected)
    {
        var actual = Day16.GetChecksum(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "01110011101111011";
        var actual = Day16.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "11001111011000111";
        var actual = Day16.Part2();
        actual.Should().Be(expected);
    }
}
