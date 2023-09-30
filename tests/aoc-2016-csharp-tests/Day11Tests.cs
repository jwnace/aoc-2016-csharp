using aoc_2016_csharp.Day11;

namespace aoc_2016_csharp_tests;

public class Day11Tests
{
    [Test]
    public void LeftShiftTests()
    {
        var foo = (1 << 10) == 0b0_0000000_0000000;
        foo.Should().BeFalse();

        var bar = (1 << 10) == 0b0_0001000_0000000;
        bar.Should().BeTrue();

        var baz = (1 << 0) == 0b0_0000000_0000001;
        baz.Should().BeTrue();

        var qux = (1 << 6) == 0b0_0000000_1000000;
        qux.Should().BeTrue();
    }

    [Test]
    public void FloorStateTests()
    {
        var floor1 = new Floor(0b1_0000001_0000001);
        var floor2 = new Floor(0b1_0011110_0000000);
        var floor3 = new Floor(0b1_0000000_0011110);
        var floor4 = new Floor(0b1_0000000_0000000);

        var state = new State(floor1, floor2, floor3, floor4);

        state.IsValid().Should().BeTrue();

        floor1.HasMicrochipA().Should().BeTrue();
        floor1.HasMicrochipB().Should().BeFalse();
        floor1.HasMicrochipC().Should().BeFalse();
        floor1.HasMicrochipD().Should().BeFalse();
        floor1.HasMicrochipE().Should().BeFalse();
        floor1.HasMicrochipF().Should().BeFalse();
        floor1.HasMicrochipG().Should().BeFalse();
        floor1.HasGeneratorA().Should().BeTrue();
        floor1.HasGeneratorB().Should().BeFalse();
        floor1.HasGeneratorC().Should().BeFalse();
        floor1.HasGeneratorD().Should().BeFalse();
        floor1.HasGeneratorE().Should().BeFalse();
        floor1.HasGeneratorF().Should().BeFalse();
        floor1.HasGeneratorG().Should().BeFalse();
        floor1.HasGenerator().Should().BeTrue();

        floor2.HasMicrochipA().Should().BeFalse();
        floor2.HasMicrochipB().Should().BeFalse();
        floor2.HasMicrochipC().Should().BeFalse();
        floor2.HasMicrochipD().Should().BeFalse();
        floor2.HasMicrochipE().Should().BeFalse();
        floor2.HasMicrochipF().Should().BeFalse();
        floor2.HasMicrochipG().Should().BeFalse();
        floor2.HasGeneratorA().Should().BeFalse();
        floor2.HasGeneratorB().Should().BeTrue();
        floor2.HasGeneratorC().Should().BeTrue();
        floor2.HasGeneratorD().Should().BeTrue();
        floor2.HasGeneratorE().Should().BeTrue();
        floor2.HasGeneratorF().Should().BeFalse();
        floor2.HasGeneratorG().Should().BeFalse();
        floor2.HasGenerator().Should().BeTrue();

        floor3.HasMicrochipA().Should().BeFalse();
        floor3.HasMicrochipB().Should().BeTrue();
        floor3.HasMicrochipC().Should().BeTrue();
        floor3.HasMicrochipD().Should().BeTrue();
        floor3.HasMicrochipE().Should().BeTrue();
        floor3.HasMicrochipF().Should().BeFalse();
        floor3.HasMicrochipG().Should().BeFalse();
        floor3.HasGeneratorA().Should().BeFalse();
        floor3.HasGeneratorB().Should().BeFalse();
        floor3.HasGeneratorC().Should().BeFalse();
        floor3.HasGeneratorD().Should().BeFalse();
        floor3.HasGeneratorE().Should().BeFalse();
        floor3.HasGeneratorF().Should().BeFalse();
        floor3.HasGeneratorG().Should().BeFalse();
        floor3.HasGenerator().Should().BeFalse();

        floor4.HasMicrochipA().Should().BeFalse();
        floor4.HasMicrochipB().Should().BeFalse();
        floor4.HasMicrochipC().Should().BeFalse();
        floor4.HasMicrochipD().Should().BeFalse();
        floor4.HasMicrochipE().Should().BeFalse();
        floor4.HasMicrochipF().Should().BeFalse();
        floor4.HasMicrochipG().Should().BeFalse();
        floor4.HasGeneratorA().Should().BeFalse();
        floor4.HasGeneratorB().Should().BeFalse();
        floor4.HasGeneratorC().Should().BeFalse();
        floor4.HasGeneratorD().Should().BeFalse();
        floor4.HasGeneratorE().Should().BeFalse();
        floor4.HasGeneratorF().Should().BeFalse();
        floor4.HasGeneratorG().Should().BeFalse();
        floor4.HasGenerator().Should().BeFalse();

        var completedFloor = new Floor(0b1_1111111_1111111);
        completedFloor.HasMicrochipA().Should().BeTrue();
        completedFloor.HasMicrochipB().Should().BeTrue();
        completedFloor.HasMicrochipC().Should().BeTrue();
        completedFloor.HasMicrochipD().Should().BeTrue();
        completedFloor.HasMicrochipE().Should().BeTrue();
        completedFloor.HasMicrochipF().Should().BeTrue();
        completedFloor.HasMicrochipG().Should().BeTrue();
        completedFloor.HasGeneratorA().Should().BeTrue();
        completedFloor.HasGeneratorB().Should().BeTrue();
        completedFloor.HasGeneratorC().Should().BeTrue();
        completedFloor.HasGeneratorD().Should().BeTrue();
        completedFloor.HasGeneratorE().Should().BeTrue();
        completedFloor.HasGeneratorF().Should().BeTrue();
        completedFloor.HasGeneratorG().Should().BeTrue();
        completedFloor.HasGenerator().Should().BeTrue();
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 33;
        var actual = Day11.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 57;
        var actual = Day11.Part2();
        actual.Should().Be(expected);
    }
}
