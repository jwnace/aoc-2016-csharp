namespace aoc_2016_csharp.Day11;

public record State(Floor Floor1, Floor Floor2, Floor Floor3, Floor Floor4)
{
    public bool IsValid() =>
        Floor1.IsValid() &&
        Floor2.IsValid() &&
        Floor3.IsValid() &&
        Floor4.IsValid();

    public int ElevatorPosition =>
        Floor1.HasElevator() ? 1 : Floor2.HasElevator() ? 2 : Floor3.HasElevator() ? 3 : 4;

    public virtual bool Equals(State? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return GetHashCode() == other.GetHashCode();
    }

    public override int GetHashCode()
    {
        var indices = new Dictionary<char, int>();

        var temp1 = HashFloor(Floor1, indices);
        var temp2 = HashFloor(Floor2, indices);
        var temp3 = HashFloor(Floor3, indices);
        var temp4 = HashFloor(Floor4, indices);

        return HashCode.Combine(temp1, temp2, temp3, temp4);
    }

    private int HashFloor(Floor floor, Dictionary<char, int> indices)
    {
        // does this floor have the elevator?
        var temp = floor & 0b1_0000000_0000000;

        // does this floor have any chip + generator pairs?
        temp = ProcessPairs(floor, indices, temp);

        // does this floor have any unpaired chips?
        temp = ProcessChips(floor, indices, temp);

        // does this floor have any unpaired generators?
        temp = ProcessGenerators(floor, indices, temp);

        return temp;
    }

    private static int ProcessPairs(Floor floor, Dictionary<char, int> indices, int temp)
    {
        for (var letter = 'A'; letter <= 'G'; letter++)
        {
            if (floor.HasMicrochip(letter) && floor.HasGenerator(letter))
            {
                var index = indices.TryGetValue(letter, out var i) ? i : indices.Count;
                indices[letter] = index;
                temp = AddPair(temp, index);
            }
        }

        return temp;
    }

    private int ProcessChips(Floor floor, Dictionary<char, int> indices, int temp)
    {
        for (var letter = 'A'; letter <= 'G'; letter++)
        {
            if (floor.HasMicrochip(letter) && !floor.HasGenerator(letter))
            {
                var index = indices.TryGetValue(letter, out var i) ? i : indices.Count;
                indices[letter] = index;
                temp = AddChip(temp, index);
            }
        }

        return temp;
    }

    private int ProcessGenerators(Floor floor, Dictionary<char, int> indices, int temp)
    {
        for (var letter = 'A'; letter <= 'G'; letter++)
        {
            if (floor.HasGenerator(letter) && !floor.HasMicrochip(letter))
            {
                var index = indices.TryGetValue(letter, out var i) ? i : indices.Count;
                indices[letter] = index;
                temp = AddGenerator(temp, index);
            }
        }

        return temp;
    }

    private int AddGenerator(int temp, int index) => temp | (1 << (index + 7));

    private int AddChip(int temp, int index) => temp | (1 << index);

    private static int AddPair(int temp, int index) => temp | (1 << index) | (1 << (index + 7));
}
