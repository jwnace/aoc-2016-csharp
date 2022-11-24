using aoc_2016_csharp.Day17;
using FluentAssertions;

namespace aoc_2016_csharp_tests;

public class Day17Tests
{
    [TestCase("hijkl", "ced9")]
    [TestCase("hijklD", "f2bc")]
    [TestCase("hijklDR", "5745")]
    [TestCase("hijklDU", "528e")]
    public void Foo(string input, string expected)
    {
        // act
        var actual = Day17.Foo(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("ihgpwlah", "DDRRRD")]
    [TestCase("kglvqrro", "DDUDRLRRUDRD")]
    [TestCase("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void Bar(string input, string expected)
    {
        // act
        var actual = Day17.Bar(input);

        // assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("ihgpwlah", 370)]
    [TestCase("kglvqrro", 492)]
    [TestCase("ulqzkmiv", 830)]
    public void Baz(string input, int expected)
    {
        // act
        var actual = Day17.Baz(input);

        // assert
        actual.Should().Be(expected);
    }
}
