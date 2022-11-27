namespace aoc_2016_csharp.Day20;

public static class Day20
{
    private static readonly string[] Input = File.ReadAllLines("Day20/day20.txt");

    public static long Part1() => GetLowestAllowedIp();

    public static long Part2() => 2;

    private static long GetLowestAllowedIp()
    {
        var ranges = Input.Select(x => (Start: long.Parse(x.Split('-')[0]), End: long.Parse(x.Split('-')[1])))
            .OrderBy(x => x.Start)
            .ThenBy(x => x.End)
            .ToList();

        for (var i = 0; i < ranges.Count - 1; i++)
        {
            var left = ranges[i];
            var right = ranges[i + 1];

            if (left.End + 1 < right.Start)
            {
                return left.End + 1;
            }
        }

        return 0;
    }
}
