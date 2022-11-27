namespace aoc_2016_csharp.Day20;

public static class Day20
{
    private static readonly string[] Input = File.ReadAllLines("Day20/day20.txt");

    public static long Part1() => GetLowestAllowedIp();

    public static long Part2() => GetAllowedIpCount();

    private static long GetLowestAllowedIp()
    {
        var blacklist = Input.Select(x => (Start: long.Parse(x.Split('-')[0]), End: long.Parse(x.Split('-')[1]))).ToList();

        for (var i = 0L; i < 4294967295L; i++)
        {
            var ranges = blacklist.Where(x => x.Start <= i && x.End >= i).ToList();

            if (!ranges.Any())
            {
                return i;
            }

            i = ranges.Max(x => x.End);
        }

        return 0;
    }

    private static long GetAllowedIpCount()
    {
        var count = 0L;
        var blacklist = Input.Select(x => (Start: long.Parse(x.Split('-')[0]), End: long.Parse(x.Split('-')[1]))).ToList();

        for (var i = 0L; i < 4294967295L; i++)
        {
            var ranges = blacklist.Where(x => x.Start <= i && x.End >= i).ToList();

            if (!ranges.Any())
            {
                count++;
                continue;
            }

            i = ranges.Max(x => x.End);
        }

        return count;
    }
}
