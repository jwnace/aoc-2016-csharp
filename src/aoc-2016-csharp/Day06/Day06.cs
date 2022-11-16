namespace aoc_2016_csharp.Day06;

public static class Day06
{
    private static readonly string[] Input = File.ReadAllLines("Day06/day06.txt");

    public static string Part1()
    {
        var result = "";

        for (var i = 0; i < Input[0].Length; i++)
        {
            result += Input.Select(x => x[i])
                .GroupBy(c => c)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .First()
                .Key;
        }

        return result;
    }

    public static string Part2()
    {
        var result = "";

        for (var i = 0; i < Input[0].Length; i++)
        {
            result += Input.Select(x => x[i])
                .GroupBy(c => c)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderBy(g => g.Count)
                .First()
                .Key;
        }

        return result;
    }
}
