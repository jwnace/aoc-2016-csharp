using System.Text;

namespace aoc_2016_csharp.Day18;

public static class Day18
{
    private static readonly string Input = File.ReadAllText("Day18/day18.txt");

    public static int Part1() => Solve(40);

    public static int Part2() => Solve(400000);

    private static int Solve(int rowCount)
    {
        var rows = new List<string> { Input };
        var row = Input;

        for (var i = 0; i < rowCount - 1; i++)
        {
            row = GetNextRow(row);
            rows.Add(row);
        }

        return rows.Sum(x => x.Count(c => c == '.'));
    }

    public static string GetNextRow(string input)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            var left = i - 1 >= 0 ? input[i - 1] : '.';
            var center = input[i];
            var right = i + 1 < input.Length ? input[i + 1] : '.';

            if ((left, center, right) is ('^', '^', '.') or ('.', '^', '^') or ('^', '.', '.') or ('.', '.', '^'))
            {
                builder.Append('^');
                continue;
            }

            builder.Append('.');
        }

        return builder.ToString();
    }
}
