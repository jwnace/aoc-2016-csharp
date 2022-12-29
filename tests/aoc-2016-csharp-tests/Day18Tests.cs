using aoc_2016_csharp.Day18;

namespace aoc_2016_csharp_tests;

public class Day18Tests
{
    [TestCase("..^^.", ".^^^^")]
    [TestCase(".^^^^", "^^..^")]
    [TestCase(".^^.^.^^^^", "^^^...^..^")]
    [TestCase("^^^...^..^", "^.^^.^.^^.")]
    [TestCase("^.^^.^.^^.", "..^^...^^^")]
    [TestCase("..^^...^^^", ".^^^^.^^.^")]
    [TestCase(".^^^^.^^.^", "^^..^.^^..")]
    [TestCase("^^..^.^^..", "^^^^..^^^.")]
    [TestCase("^^^^..^^^.", "^..^^^^.^^")]
    [TestCase("^..^^^^.^^", ".^^^..^.^^")]
    [TestCase(".^^^..^.^^", "^^.^^^..^^")]
    public void GetNextRowTest(string input, string expected)
    {
        var actual = Day18.GetNextRow(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1_926;
        var actual = Day18.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 19_986_699;
        var actual = Day18.Part2();
        actual.Should().Be(expected);
    }
}
