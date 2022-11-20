namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private static readonly string[] Input = File.ReadAllLines("Day11/day11.txt");

    public static int Part1()
    {
        var state = new string[,]
        {
            // A = promethium
            // B = cobalt
            // C = curium
            // D = ruthenium
            // E = plutonium
            { "E", "AG", "AM", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " }, // first floor
            { "E", "  ", "  ", "BG", "  ", "CG", "  ", "DG", "  ", "EG", "  " }, // second floor
            { "E", "  ", "  ", "  ", "BM", "  ", "CM", "  ", "DM", "  ", "EM" }, // third floor
            { "E", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " }, // fourth floor
        };

        return 1;
    }

    public static int Part2()
    {
        return 2;
    }
}
