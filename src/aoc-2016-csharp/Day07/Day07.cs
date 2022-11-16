using System.Text.RegularExpressions;

namespace aoc_2016_csharp.Day07;

public static class Day07
{
    private static readonly string[] Input = File.ReadAllLines("Day07/day07.txt");

    public static int Part1()
    {
        var count = 0;

        foreach (var line in Input)
        {
            var buffer = "";
            var bracketedStrings = new List<string>();
            var unbracketedStrings = new List<string>();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '[')
                {
                    // ContainsAbba(buffer);
                    unbracketedStrings.Add(buffer);
                    buffer = "";
                    continue;
                }

                if (line[i] == ']')
                {
                    // ContainsAbba(buffer);
                    bracketedStrings.Add(buffer);
                    buffer = "";
                    continue;
                }

                buffer += line[i];
            }

            if (buffer.Length > 0)
            {
                // ContainsAbba(buffer);
                unbracketedStrings.Add(buffer);
            }

            var supportsTls = unbracketedStrings.Any(ContainsAbba) && !bracketedStrings.Any(ContainsAbba);

            count += supportsTls ? 1 : 0;

            // Console.WriteLine($"{supportsTls} -> {line}");
        }

        return count;
    }

    public static int Part2()
    {
        var count = 0;

        foreach (var line in Input)
        {
            var buffer = "";
            var bracketedStrings = new List<string>();
            var unbracketedStrings = new List<string>();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '[')
                {
                    // ContainsAbba(buffer);
                    unbracketedStrings.Add(buffer);
                    buffer = "";
                    continue;
                }

                if (line[i] == ']')
                {
                    // ContainsAbba(buffer);
                    bracketedStrings.Add(buffer);
                    buffer = "";
                    continue;
                }

                buffer += line[i];
            }

            if (buffer.Length > 0)
            {
                // ContainsAbba(buffer);
                unbracketedStrings.Add(buffer);
            }

            // var supportsSsl = unbracketedStrings.Any(ContainsAba) && bracketedStrings.Any(ContainsBab);

            var abas = GetAbas(unbracketedStrings).Distinct();

            var supportsSsl = false;

            foreach (var aba in abas)
            {
                var bab = "" + aba[1] + aba[0] + aba[1];

                if (bracketedStrings.Any(x => x.Contains(bab)))
                {
                    supportsSsl = true;
                }
            }

            count += supportsSsl ? 1 : 0;

            // Console.WriteLine($"{supportsTls} -> {line}");
        }

        return count;
    }

    private static bool ContainsAbba(string input)
    {
        var buffer = "";

        for (int i = 0; i < input.Length; i++)
        {
            buffer += input[i];

            if (buffer.Length < 4)
            {
                continue;
            }

            if (buffer.Length > 4)
            {
                buffer = buffer[^4..];
            }

            if (buffer[0] == buffer[3] && buffer[1] == buffer[2] && buffer[0] != buffer[1])
            {
                // Console.WriteLine($"{input} has an ABBA");
                return true;
            }
        }

        // Console.WriteLine($"{input} does not have an ABBA");
        return false;
    }

    private static List<string> GetAbas(List<string> unbracketedStrings)
    {
        var abas = new List<string>();
        var buffer = "";

        foreach (var str in unbracketedStrings)
        {
            for (var i = 0; i < str.Length; i++)
            {
                buffer += str[i];

                if (buffer.Length < 3)
                {
                    continue;
                }

                if (buffer.Length > 3)
                {
                    buffer = buffer[^3..];
                }

                if (buffer[0] == buffer[2] && buffer[0] != buffer[1])
                {
                    abas.Add(buffer);
                }
            }
        }

        return abas;
    }
}
