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

        for (var i = 0; i < Input.Length; i++)
        {
            var line = Input[i];
            var temp = line.Split(' ');
            var instruction = temp[0];

            if (instruction == "cpy")
            {
                var x = temp[1];
                var y = temp[2];

                registers[y] = int.TryParse(x, out var foo) ? foo : registers[x];
            }
            else if (instruction == "inc")
            {
                var x = temp[1];

                registers[x] += 1;
            }
            else if (instruction == "dec")
            {
                var x = temp[1];

                registers[x] -= 1;
            }
            else if (instruction == "jnz")
            {
                var x = temp[1];
                var y = temp[2];

                var xValue = int.TryParse(x, out var foo) ? foo : registers[x];
                var yValue = int.TryParse(y, out var bar) ? bar : registers[y];

                if (xValue != 0)
                {
                    i += yValue - 1;
                }
            }
            else
            {
                throw new InvalidOperationException($"unsupported instruction: {instruction}");
            }
        }

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

        for (var i = 0; i < Input.Length; i++)
        {
            var line = Input[i];
            var temp = line.Split(' ');
            var instruction = temp[0];

            if (instruction == "cpy")
            {
                var x = temp[1];
                var y = temp[2];

                registers[y] = int.TryParse(x, out var foo) ? foo : registers[x];
            }
            else if (instruction == "inc")
            {
                var x = temp[1];

                registers[x] += 1;
            }
            else if (instruction == "dec")
            {
                var x = temp[1];

                registers[x] -= 1;
            }
            else if (instruction == "jnz")
            {
                var x = temp[1];
                var y = temp[2];

                var xValue = int.TryParse(x, out var foo) ? foo : registers[x];
                var yValue = int.TryParse(y, out var bar) ? bar : registers[y];

                if (xValue != 0)
                {
                    i += yValue - 1;
                }
            }
            else
            {
                throw new InvalidOperationException($"unsupported instruction: {instruction}");
            }
        }

        return registers["a"];
    }
}
