namespace aoc_2016_csharp.Day12;

public static class Day12
{
    private static readonly string[] Input = File.ReadAllLines("Day12/day12.txt");

    public static int Part1()
    {
        var registers = new Dictionary<string, int>
        {
            { "a", 0 },
            { "b", 0 },
            { "c", 0 },
            { "d", 0 },
        };

        Run(registers);

        return registers["a"];
    }

    public static int Part2()
    {
        var registers = new Dictionary<string, int>
        {
            { "a", 0 },
            { "b", 0 },
            { "c", 1 },
            { "d", 0 },
        };

        Run(registers);

        return registers["a"];
    }

    private static void Run(Dictionary<string, int> registers)
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
        }
    }
}
