namespace aoc_2016_csharp.Day11;

public record State(Floor FirstFloor, Floor SecondFloor, Floor ThirdFloor, Floor FourthFloor)
{
    public bool IsValid() =>
        FirstFloor.IsValid() && SecondFloor.IsValid() && ThirdFloor.IsValid() && FourthFloor.IsValid();

    public int ElevatorPosition =>
        FirstFloor.HasElevator() ? 1 : SecondFloor.HasElevator() ? 2 : ThirdFloor.HasElevator() ? 3 : 4;

    public virtual bool Equals(State? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        // var equal = FirstFloor.Equals(other.FirstFloor) &&
        // SecondFloor.Equals(other.SecondFloor) &&
        // ThirdFloor.Equals(other.ThirdFloor) &&
        // FourthFloor.Equals(other.FourthFloor);

        return this.GetHashCode() == other.GetHashCode();
    }

    public override int GetHashCode()
    {
        var indices = new Dictionary<char, int>();

        var temp1 = HashFloor(FirstFloor, ref indices);
        var temp2 = HashFloor(SecondFloor, ref indices);
        var temp3 = HashFloor(ThirdFloor, ref indices);
        var temp4 = HashFloor(FourthFloor, ref indices);

        if (indices.Count is not (5 or 7))
        {
            throw new Exception("SOMETHING WENT WRONG");
        }

        return HashCode.Combine(
            temp1,
            temp2,
            temp3,
            temp4);
    }

    private int HashFloor(Floor floor, ref Dictionary<char, int> indices)
    {
        // does this floor have the elevator?
        var temp = floor & 0b1_0000000_0000000;

        // does this floor have any chip + generator pairs?
        {
            if (floor.HasMicrochipA() && floor.HasGeneratorA())
            {
                var index = indices.TryGetValue('A', out var i) ? i : indices.Count;
                indices['A'] = index;
                temp = AddPair(temp, index);
            }

            if (floor.HasMicrochipB() && floor.HasGeneratorB())
            {
                var index = indices.TryGetValue('B', out var i) ? i : indices.Count;
                indices['B'] = index;
                temp = AddPair(temp, index);
            }

            if (floor.HasMicrochipC() && floor.HasGeneratorC())
            {
                var index = indices.TryGetValue('C', out var i) ? i : indices.Count;
                indices['C'] = index;
                temp = AddPair(temp, index);
            }

            if (floor.HasMicrochipD() && floor.HasGeneratorD())
            {
                var index = indices.TryGetValue('D', out var i) ? i : indices.Count;
                indices['D'] = index;
                temp = AddPair(temp, index);
            }

            if (floor.HasMicrochipE() && floor.HasGeneratorE())
            {
                var index = indices.TryGetValue('E', out var i) ? i : indices.Count;
                indices['E'] = index;
                temp = AddPair(temp, index);
            }

            if (floor.HasMicrochipF() && floor.HasGeneratorF())
            {
                var index = indices.TryGetValue('F', out var i) ? i : indices.Count;
                indices['F'] = index;
                temp = AddPair(temp, index);
            }

            if (floor.HasMicrochipG() && floor.HasGeneratorG())
            {
                var index = indices.TryGetValue('G', out var i) ? i : indices.Count;
                indices['G'] = index;
                temp = AddPair(temp, index);
            }
        }

        // does this floor have any unpaired chips?
        {
            if (floor.HasMicrochipA() && !floor.HasGeneratorA())
            {
                var index = indices.TryGetValue('A', out var i) ? i : indices.Count;
                indices['A'] = index;
                temp = AddChip(temp, index);
            }

            if (floor.HasMicrochipB() && !floor.HasGeneratorB())
            {
                var index = indices.TryGetValue('B', out var i) ? i : indices.Count;
                indices['B'] = index;
                temp = AddChip(temp, index);
            }

            if (floor.HasMicrochipC() && !floor.HasGeneratorC())
            {
                var index = indices.TryGetValue('C', out var i) ? i : indices.Count;
                indices['C'] = index;
                temp = AddChip(temp, index);
            }

            if (floor.HasMicrochipD() && !floor.HasGeneratorD())
            {
                var index = indices.TryGetValue('D', out var i) ? i : indices.Count;
                indices['D'] = index;
                temp = AddChip(temp, index);
            }

            if (floor.HasMicrochipE() && !floor.HasGeneratorE())
            {
                var index = indices.TryGetValue('E', out var i) ? i : indices.Count;
                indices['E'] = index;
                temp = AddChip(temp, index);
            }

            if (floor.HasMicrochipF() && !floor.HasGeneratorF())
            {
                var index = indices.TryGetValue('F', out var i) ? i : indices.Count;
                indices['F'] = index;
                temp = AddChip(temp, index);
            }

            if (floor.HasMicrochipG() && !floor.HasGeneratorG())
            {
                var index = indices.TryGetValue('G', out var i) ? i : indices.Count;
                indices['G'] = index;
                temp = AddChip(temp, index);
            }
        }

        // does this floor have any unpaired generators?
        {
            if (floor.HasGeneratorA() && !floor.HasMicrochipA())
            {
                var index = indices.TryGetValue('A', out var i) ? i : indices.Count;
                indices['A'] = index;
                temp = AddGenerator(temp, index);
            }

            if (floor.HasGeneratorB() && !floor.HasMicrochipB())
            {
                var index = indices.TryGetValue('B', out var i) ? i : indices.Count;
                indices['B'] = index;
                temp = AddGenerator(temp, index);
            }

            if (floor.HasGeneratorC() && !floor.HasMicrochipC())
            {
                var index = indices.TryGetValue('C', out var i) ? i : indices.Count;
                indices['C'] = index;
                temp = AddGenerator(temp, index);
            }

            if (floor.HasGeneratorD() && !floor.HasMicrochipD())
            {
                var index = indices.TryGetValue('D', out var i) ? i : indices.Count;
                indices['D'] = index;
                temp = AddGenerator(temp, index);
            }

            if (floor.HasGeneratorE() && !floor.HasMicrochipE())
            {
                var index = indices.TryGetValue('E', out var i) ? i : indices.Count;
                indices['E'] = index;
                temp = AddGenerator(temp, index);
            }

            if (floor.HasGeneratorF() && !floor.HasMicrochipF())
            {
                var index = indices.TryGetValue('F', out var i) ? i : indices.Count;
                indices['F'] = index;
                temp = AddGenerator(temp, index);
            }

            if (floor.HasGeneratorG() && !floor.HasMicrochipG())
            {
                var index = indices.TryGetValue('G', out var i) ? i : indices.Count;
                indices['G'] = index;
                temp = AddGenerator(temp, index);
            }
        }

        return temp;
    }

    private int AddGenerator(int temp, int index)
    {
        return temp | (1 << (index + 7));
    }

    private int AddChip(int temp, int index)
    {
        return temp | (1 << index);
    }

    private static int AddPair(int temp, int index)
    {
        var mask = index switch
        {
            0 => 0b0_0000001_0000001,
            1 => 0b0_0000010_0000010,
            2 => 0b0_0000100_0000100,
            3 => 0b0_0001000_0001000,
            4 => 0b0_0010000_0010000,
            5 => 0b0_0100000_0100000,
            6 => 0b0_1000000_1000000,
            _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
        };

        return temp | mask;
    }
}
