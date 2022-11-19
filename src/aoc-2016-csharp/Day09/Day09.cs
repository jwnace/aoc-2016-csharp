namespace aoc_2016_csharp.Day09;

public static class Day09
{
    private static readonly string Input = File.ReadAllText("Day09/day09.txt");

    public static int Part1() => DecompressStringVersionOne(Input).Length;

    public static long Part2() => GetDecompressedLength(Input);

    public static string DecompressStringVersionOne(string input)
    {
        if (!input.Contains('('))
        {
            return input;
        }

        var buffer = "";

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                var j = input.IndexOf(')', i);
                var values = input[(i + 1)..j].Split('x');
                var length = int.Parse(values[0]);
                var times = int.Parse(values[1]);
                var sequence = input.Substring(j + 1, length);

                for (var k = 0; k < times; k++)
                {
                    buffer += sequence;
                }

                i = j + length;
                continue;
            }

            if (input[i] != ')')
            {
                buffer += input[i];
            }
        }

        return buffer;
    }

    public static string DecompressStringVersionTwo(string input)
    {
        var output = input;

        while (output.Contains('('))
        {
            output = DecompressStringVersionOne(output);
        }

        return output;
    }

    public static long GetDecompressedLength(string input)
    {
        if (!input.Contains('('))
        {
            return input.Length;
        }

        var result = 0L;
        var weights = new int[input.Length];
        Array.Fill(weights, 1);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                var j = input.IndexOf(')', i);
                var values = input[(i + 1)..j].Split('x');
                var length = int.Parse(values[0]);
                var times = int.Parse(values[1]);

                for (var k = j + 1; k < j + 1 + length; k++)
                {
                    weights[k] *= times;
                }

                i = j;
                continue;
            }

            if (input[i] != ')')
            {
                result += weights[i];
            }
        }

        return result;
    }
}
