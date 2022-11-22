namespace aoc_2016_csharp.Day15;

public static class Day15
{
    private static readonly string[] Input = File.ReadAllLines("Day15/day15.txt");

    private record Disc(int Positions, int StartingPosition)
    {
        public int GetPosition(int time) => (StartingPosition + time) % Positions;
    }

    public static int Part1()
    {
        var discs = InitializeDiscs();
        return GetIdealDropTime(discs);
    }

    public static int Part2()
    {
        var discs = InitializeDiscs();
        discs.Add(new Disc(11, 0));
        return GetIdealDropTime(discs);
    }
    
    private static List<Disc> InitializeDiscs()
    {
        var discs = new List<Disc>();

        foreach (var line in Input)
        {
            var temp = line.Split(' ');
            var positions = int.Parse(temp[3]);
            var startingPosition = int.Parse(temp[^1][..^1]);

            discs.Add(new Disc(positions, startingPosition));
        }

        return discs;
    }

    private static int GetIdealDropTime(IEnumerable<Disc> discs)
    {
        for (var time = 0; time < int.MaxValue; time++)
        {
            if (CanCapsuleFallThrough(discs, time))
            {
                return time;
            }
        }

        return 0;
    }

    private static bool CanCapsuleFallThrough(IEnumerable<Disc> discs, int time) =>
        discs.Select((disc, index) => disc.GetPosition(time + index + 1) == 0).All(x => x);
}
