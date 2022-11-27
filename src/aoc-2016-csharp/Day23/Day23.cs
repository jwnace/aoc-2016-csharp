namespace aoc_2016_csharp.Day23;

public static class Day23
{
    public static int Part1()
    {
        var registers = new Dictionary<string, int> { { "a", 7 }, { "b", 0 }, { "c", 0 }, { "d", 0 } };

        Run(registers);

        return registers["a"];
    }

    public static int Part2()
    {
        var registers = new Dictionary<string, int> { { "a", 12 }, { "b", 0 }, { "c", 0 }, { "d", 0 } };

        Run(registers);

        return registers["a"];
    }

    private static void Run(Dictionary<string, int> registers)
    {
        var input = File.ReadAllLines("Day23/day23.txt");

        for (var i = 0; i < input.Length; i++)
        {
            var values = input[i].Split(' ');
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

                if (i + xValue < input.Length)
                {
                    input[i + xValue] = Toggle(input[i + xValue]);
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
