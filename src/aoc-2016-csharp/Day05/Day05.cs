using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day05;

public static class Day05
{
    private static readonly string Input = File.ReadAllText("Day05/day05.txt");

    public static string Part1()
    {
        var password = "";

        for (var i = 0; i < int.MaxValue; i++)
        {
            var temp = Input + i;
            var md5 = temp.ToMd5String();

            if (!md5.StartsWith("00000"))
            {
                continue;
            }

            password += md5[5];

            if (password.Length == 8)
            {
                return password.ToLower();
            }
        }

        return "";
    }

    public static string Part2()
    {
        var password = "________";

        for (var i = 0; i < int.MaxValue; i++)
        {
            var temp = Input + i;
            var md5 = temp.ToMd5String();

            if (!md5.StartsWith("00000") || !int.TryParse(md5[5].ToString(), out var j) || j > 7 || password[j] != '_')
            {
                continue;
            }

            password = password[..j] + md5[6] + password[(j + 1)..];

            if (!password.Contains('_'))
            {
                return password.ToLower();
            }
        }

        return "";
    }
}
