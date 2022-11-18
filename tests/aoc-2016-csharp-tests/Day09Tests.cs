using aoc_2016_csharp.Day09;
using FluentAssertions;

namespace aoc_2016_csharp_tests;

public class Day09Tests
{
    [TestCase("ADVENT", "ADVENT")]
    [TestCase("A(1x5)BC", "ABBBBBC")]
    [TestCase("(3x3)XYZ", "XYZXYZXYZ")]
    [TestCase("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG")]
    [TestCase("(6x1)(1x3)A", "(1x3)A")]
    [TestCase("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY")]
    public void DecompressStringVersionOneTest(string input, string expected)
    {
        // act
        var actual = Day09.DecompressStringVersionOne(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("ADVENT", "ADVENT")]
    [TestCase("A(1x5)BC", "ABBBBBC")]
    [TestCase("(3x3)XYZ", "XYZXYZXYZ")]
    [TestCase("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG")]
    [TestCase("(6x1)(1x3)A", "AAA")]
    [TestCase("X(8x2)(3x3)ABCY", "XABCABCABCABCABCABCY")]
    public void DecompressStringVersionTwoTest(string input, string expected)
    {
        // act
        var actual = Day09.DecompressStringVersionTwo(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("ADVENT", 6)]
    [TestCase("A(1x5)BC", 7)]
    [TestCase("(3x3)XYZ", 9)]
    [TestCase("A(2x2)BCD(2x2)EFG", 11)]
    [TestCase("(6x1)(1x3)A", 3)]
    [TestCase("X(8x2)(3x3)ABCY", 20)]
    [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
    [TestCase("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
    public void GetDecompressedLengthTest(string input, int expectedLength)
    {
        // act
        var actual = Day09.GetDecompressedLength(input);

        // assert
        actual.Should().Be(expectedLength);
    }
}
