namespace aoc_2016_csharp.Day19;

public static class Day19
{
    private static readonly int Input = int.Parse(File.ReadAllText("Day19/day19.txt"));

    private record Elf(int Number)
    {
        public Elf Previous { get; set; } = null!;
        public Elf Next { get; set; } = null!;
    }

    public static int Part1() => SolvePart1(Input);

    public static int Part2() => SolvePart2(Input);

    private static Elf[] BuildElfCircle(int elfCount)
    {
        var elves = new Elf[elfCount];
        var root = new Elf(1);
        var previous = root;
        elves[0] = root;

        for (var i = 1; i < elfCount; i++)
        {
            var next = new Elf(i + 1);
            previous.Next = next;
            next.Previous = previous;
            previous = next;
            elves[i] = next;
        }

        previous.Next = root;
        root.Previous = previous;

        return elves;
    }

    public static int SolvePart1(int elfCount)
    {
        var elves = BuildElfCircle(elfCount);
        var elf = elves[0];
        var target = elf.Next;

        while (elf.Next != elf)
        {
            target.Previous.Next = target.Next;
            target.Next.Previous = target.Previous;

            elf = target.Next;
            target = elf.Next;
        }

        return elf.Number;
    }

    public static int SolvePart2(int elfCount)
    {
        var elves = BuildElfCircle(elfCount);
        var elf = elves[0];
        var target = elves[elfCount / 2];

        var count = elfCount;

        while (elf.Next != elf)
        {
            target.Previous.Next = target.Next;
            target.Next.Previous = target.Previous;

            target = count % 2 == 1 ? target.Next.Next : target.Next;

            elf = elf.Next;
            count--;
        }

        return elf.Number;
    }
}
