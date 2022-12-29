namespace aoc_2016_csharp.Day25;

public static class Day25
{
    private static readonly string[] Input = File.ReadAllLines("Day25/day25.txt");

    public static int Part1()
    {
        for (var i = 0; i < int.MaxValue; i++)
        {
            var output = new List<int>();
            var registers = new Dictionary<string, int> { { "a", i }, { "b", 0 }, { "c", 0 }, { "d", 0 } };
            var expected = new[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, };

            Run(registers, ref output);

            if (output.SequenceEqual(expected))
            {
                return i;
            }
        }

        return 1;
    }

    public static string Part2() => "Merry Christmas!";

    private static void Run(Dictionary<string, int> registers, ref List<int> output)
    {
        for (var i = 0; i < Input.Length; i++)
        {
            var values = Input[i].Split(' ');
            var instruction = values[0];

            if (instruction == "cpy")
            {
                var (x, y) = (values[1], values[2]);
                registers[y] = int.TryParse(x, out var result) ? result : registers[x];
            }
            else if (instruction == "inc")
            {
                var x = values[1];
                registers[x] += 1;
            }
            else if (instruction == "dec")
            {
                var x = values[1];
                registers[x] -= 1;
            }
            else if (instruction == "jnz")
            {
                var (x, y) = (values[1], values[2]);

                var xValue = int.TryParse(x, out var xResult) ? xResult : registers[x];
                var yValue = int.TryParse(y, out var yResult) ? yResult : registers[y];

                if (xValue != 0)
                {
                    i += yValue - 1;
                }
            }
            else if (instruction == "tgl")
            {
                var x = values[1];
                var xValue = int.TryParse(x, out var xResult) ? xResult : registers[x];

                if (i + xValue < Input.Length)
                {
                    Input[i + xValue] = Toggle(Input[i + xValue]);
                }
            }
            else if (instruction == "out")
            {
                var x = values[1];
                var xValue = int.TryParse(x, out var xResult) ? xResult : registers[x];

                output.Add(xValue);

                if (output.Count >= 10)
                {
                    return;
                }
            }
            else
            {
                throw new InvalidOperationException($"Unsupported Instruction: {instruction}");
            }
        }
    }

    private static string Toggle(string instruction) =>
        instruction[..3] switch
        {
            "inc" => instruction.Replace("inc", "dec"),
            "dec" => instruction.Replace("dec", "inc"),
            "tgl" => instruction.Replace("tgl", "inc"),
            "jnz" => instruction.Replace("jnz", "cpy"),
            "cpy" => instruction.Replace("cpy", "jnz"),
            _ => throw new InvalidOperationException()
        };
}
