using aoc_2016_csharp.Day17;

namespace aoc_2016_csharp_tests;

public class Day17Tests
{
    [TestCase("hijkl", "ced9")]
    [TestCase("hijklD", "f2bc")]
    [TestCase("hijklDR", "5745")]
    [TestCase("hijklDU", "528e")]
    public void GetDoorStatesTest(string input, string expected)
    {
        var actual = Day17.GetDoorStates(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("ihgpwlah", "DDRRRD")]
    [TestCase("kglvqrro", "DDUDRLRRUDRD")]
    [TestCase("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void GetShortestPathTest(string input, string expected)
    {
        var actual = Day17.GetShortestPath(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase("ihgpwlah", 370)]
    [TestCase("kglvqrro", 492)]
    [TestCase("ulqzkmiv", 830)]
    public void GetLongestPathLengthTest(string input, int expected)
    {
        var actual = Day17.GetLongestPathLength(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "RDURRDDLRD";
        var actual = Day17.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 526;
        var actual = Day17.Part2();
        actual.Should().Be(expected);
    }
}
