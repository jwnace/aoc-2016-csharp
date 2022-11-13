namespace aoc_2016_csharp.Day02;

public static class Day02
{
    private static readonly string[] Input = File.ReadAllLines("Day02/day02.txt");

    public static string Part1()
    {
        var startingPosition = (Col: 1, Row: 1);
        var grid = new[]
        {
            "_____",
            "_123_",
            "_456_",
            "_789_",
            "_____"
        };

        return GetCode(startingPosition, grid);
    }

    public static string Part2()
    {
        var startingPosition = (Col: 1, Row: 3);
        var grid = new[]
        {
            "_______",
            "___1___",
            "__234__",
            "_56789_",
            "__ABC__",
            "___D___",
            "_______"
        };

        return GetCode(startingPosition, grid);
    }

    private static string GetCode((int Col, int Row) position, IReadOnlyList<string> grid)
    {
        var code = "";

        foreach (var line in Input)
        {
            foreach (var c in line)
            {
                var newPosition = c switch
                {
                    'U' => position with { Row = position.Row - 1 },
                    'R' => position with { Col = position.Col + 1 },
                    'D' => position with { Row = position.Row + 1 },
                    'L' => position with { Col = position.Col - 1 },
                    _ => throw new ArgumentOutOfRangeException()
                };

                if (grid[newPosition.Row][newPosition.Col] != '_')
                {
                    position = newPosition;
                }
            }

            var digit = grid[position.Row][position.Col];
            code += digit;
        }

        return code;
    }
}
