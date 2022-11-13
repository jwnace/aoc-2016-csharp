namespace aoc_2016_csharp.Day02;

public static class Day02
{
    private static readonly string[] Input = File.ReadAllLines("Day02/day02.txt");

    public static string Part1()
    {
        var position = (X: 1, Y: 1);
        var code = "";

        foreach (var line in Input)
        {
            foreach (var c in line)
            {
                position = c switch
                {
                    'U' => (position.X, position.Y - 1),
                    'R' => (position.X + 1, position.Y),
                    'D' => (position.X, position.Y + 1),
                    'L' => (position.X - 1, position.Y),
                };

                if (position.X < 0)
                {
                    position.X = 0;
                }

                if (position.X > 2)
                {
                    position.X = 2;
                }

                if (position.Y < 0)
                {
                    position.Y = 0;
                }

                if (position.Y > 2)
                {
                    position.Y = 2;
                }
            }

            var digit = position switch
            {
                (0, 0) => 1,
                (1, 0) => 2,
                (2, 0) => 3,
                (0, 1) => 4,
                (1, 1) => 5,
                (2, 1) => 6,
                (0, 2) => 7,
                (1, 2) => 8,
                (2, 2) => 9,
            };

            code += digit;
        }

        return code;
    }

    public static string Part2()
    {
        var position = (X: 1, Y: 3);
        var code = "";
        var grid = new string[]
        {
            "_______",
            "___1___",
            "__234__",
            "_56789_",
            "__ABC__",
            "___D___",
            "_______"
        };

        Console.WriteLine($"Starting at {grid[position.X][position.Y]}");

        foreach (var line in Input)
        {
            foreach (var c in line)
            {
                var newPosition = c switch
                {
                    'U' => (X: position.X, Y: position.Y - 1),
                    'R' => (X: position.X + 1, Y: position.Y),
                    'D' => (X: position.X, Y: position.Y + 1),
                    'L' => (X: position.X - 1, Y: position.Y),
                };

                if (grid[newPosition.X][newPosition.Y] != '_')
                {
                    position = newPosition;
                }
            }

            var digit = grid[position.Y][position.X];
            code += digit;
        }

        return code;
    }
}
