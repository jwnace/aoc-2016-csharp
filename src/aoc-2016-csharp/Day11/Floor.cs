namespace aoc_2016_csharp.Day11;

public record Floor(int FloorState)
{
    public static implicit operator int(Floor floor) => floor.FloorState;
    public static implicit operator Floor(int floorState) => new(floorState);

    public bool HasMicrochipA() => (FloorState & 1 << 0) > 0;
    public bool HasMicrochipB() => (FloorState & 1 << 1) > 0;
    public bool HasMicrochipC() => (FloorState & 1 << 2) > 0;
    public bool HasMicrochipD() => (FloorState & 1 << 3) > 0;
    public bool HasMicrochipE() => (FloorState & 1 << 4) > 0;
    public bool HasMicrochipF() => (FloorState & 1 << 5) > 0;
    public bool HasMicrochipG() => (FloorState & 1 << 6) > 0;

    public bool HasGeneratorA() => (FloorState & 1 << 7) > 0;
    public bool HasGeneratorB() => (FloorState & 1 << 8) > 0;
    public bool HasGeneratorC() => (FloorState & 1 << 9) > 0;
    public bool HasGeneratorD() => (FloorState & 1 << 10) > 0;
    public bool HasGeneratorE() => (FloorState & 1 << 11) > 0;
    public bool HasGeneratorF() => (FloorState & 1 << 12) > 0;
    public bool HasGeneratorG() => (FloorState & 1 << 13) > 0;

    public bool HasElevator() => (FloorState & 1 << 14) > 0;

    public bool HasMicrochip(char letter)
    {
        return letter switch
        {
            'A' => HasMicrochipA(),
            'B' => HasMicrochipB(),
            'C' => HasMicrochipC(),
            'D' => HasMicrochipD(),
            'E' => HasMicrochipE(),
            'F' => HasMicrochipF(),
            'G' => HasMicrochipG(),
            _ => throw new ArgumentOutOfRangeException(nameof(letter), letter, "Invalid letter")
        };
    }

    public bool HasGenerator(char letter)
    {
        return letter switch
        {
            'A' => HasGeneratorA(),
            'B' => HasGeneratorB(),
            'C' => HasGeneratorC(),
            'D' => HasGeneratorD(),
            'E' => HasGeneratorE(),
            'F' => HasGeneratorF(),
            'G' => HasGeneratorG(),
            _ => throw new ArgumentOutOfRangeException(nameof(letter), letter, "Invalid letter")
        };
    }

    private bool HasUnprotectedChip() =>
        HasUnprotectedChipA() ||
        HasUnprotectedChipB() ||
        HasUnprotectedChipC() ||
        HasUnprotectedChipD() ||
        HasUnprotectedChipE() ||
        HasUnprotectedChipF() ||
        HasUnprotectedChipG();

    private bool HasUnprotectedChipA() => (FloorState & 0b0_0000001_0000001) == 0b0_0000000_0000001;
    private bool HasUnprotectedChipB() => (FloorState & 0b0_0000010_0000010) == 0b0_0000000_0000010;
    private bool HasUnprotectedChipC() => (FloorState & 0b0_0000100_0000100) == 0b0_0000000_0000100;
    private bool HasUnprotectedChipD() => (FloorState & 0b0_0001000_0001000) == 0b0_0000000_0001000;
    private bool HasUnprotectedChipE() => (FloorState & 0b0_0010000_0010000) == 0b0_0000000_0010000;
    private bool HasUnprotectedChipF() => (FloorState & 0b0_0100000_0100000) == 0b0_0000000_0100000;
    private bool HasUnprotectedChipG() => (FloorState & 0b0_1000000_1000000) == 0b0_0000000_1000000;

    public bool HasGenerator() => (FloorState & 0b0_1111111_0000000) > 0;

    public bool IsValid() => !HasGenerator() || !HasUnprotectedChip();
}
