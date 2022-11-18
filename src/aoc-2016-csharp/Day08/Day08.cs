namespace aoc_2016_csharp.Day08;

public static class Day08
{
    private static readonly string[] Input = File.ReadAllLines("Day08/day08.txt");

    public static int Part1() => GenerateScreenOutput().SelectMany(x => x).Count(x => x == '#');

    public static string Part2() =>
        GenerateScreenOutput().Aggregate(Environment.NewLine, (current, row) => current + row + Environment.NewLine);

    private static List<string> GenerateScreenOutput()
    {
        var screen = new List<string>
        {
            "                                                  ",
            "                                                  ",
            "                                                  ",
            "                                                  ",
            "                                                  ",
            "                                                  ",
        };

        foreach (var line in Input)
        {
            var parts = line.Split(' ');
            var command = parts[0];

            if (command == "rect")
            {
                var temp = parts[1].Split('x');
                var (a, b) = (int.Parse(temp[0]), int.Parse(temp[1]));
                screen = Rect(screen, a, b);
            }
            else if (command == "rotate")
            {
                var type = parts[1];

                if (type == "row")
                {
                    var row = int.Parse(parts[2][2..]);
                    var shift = int.Parse(parts[4]);
                    screen = RotateRow(screen, row, shift);
                }
                else if (type == "column")
                {
                    var col = int.Parse(parts[2][2..]);
                    var shift = int.Parse(parts[4]);
                    screen = RotateCol(screen, col, shift);
                }
            }
        }

        return screen;
    }

    private static List<string> Rect(List<string> screen, int a, int b)
    {
        var buffer = screen.Select(x => x.ToCharArray()).ToArray();

        for (var i = 0; i < b; i++)
        {
            for (var j = 0; j < a; j++)
            {
                buffer[i][j] = '#';
            }
        }

        return buffer.Select(x => new string(x)).ToList();
    }

    private static List<string> RotateRow(List<string> screen, int row, int shift)
    {
        var buffer = screen.Select(x => x.ToCharArray()).ToArray();

        buffer[row] = buffer[row].Select((c, i) => new { NewIndex = (i + shift) % buffer[row].Length, Value = c })
            .OrderBy(x => x.NewIndex)
            .Select(x => x.Value)
            .ToArray();

        return buffer.Select(x => new string(x)).ToList();
    }

    private static List<string> RotateCol(List<string> screen, int col, int shift)
    {
        var buffer = screen.Select(x => x.ToCharArray()).ToArray();

        for (var i = 0; i < buffer.Length; i++)
        {
            var newRow = (i + shift) % buffer.Length;
            buffer[newRow][col] = screen[i][col];
        }

        return buffer.Select(x => new string(x)).ToList();
    }
}
