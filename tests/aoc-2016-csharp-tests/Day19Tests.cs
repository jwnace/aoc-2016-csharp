﻿using aoc_2016_csharp.Day19;

namespace aoc_2016_csharp_tests;

public class Day19Tests
{
    [TestCase(5, 3)]
    [TestCase(3004953, 1815603)]
    public void SolvePart1Test(int input, int expected)
    {
        var actual = Day19.SolvePart1(input);
        actual.Should().Be(expected);
    }

    [TestCase(5, 2)]
    [TestCase(3004953, 1410630)]
    public void SolvePart2Test(int input, int expected)
    {
        var actual = Day19.SolvePart2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1_815_603;
        var actual = Day19.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1_410_630;
        var actual = Day19.Part2();
        actual.Should().Be(expected);
    }
}
