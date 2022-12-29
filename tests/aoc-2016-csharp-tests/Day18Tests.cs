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
        // act
        var actual = Day18.GetNextRow(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }
}
