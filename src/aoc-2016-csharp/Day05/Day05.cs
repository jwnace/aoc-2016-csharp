using System.Security.Cryptography;
using System.Text;

namespace aoc_2016_csharp.Day05;

public static class Day05
{
    private static readonly string Input = File.ReadAllText("Day05/day05.txt");

    public static string Part1()
    {
        var password = "";

        for (int i = 0; i < int.MaxValue; i++)
        {
            var md5 = CreateMD5(Input + i);

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
            var md5 = CreateMD5(Input + i);

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

    private static string CreateMD5(string input)
    {
        using (var md5 = MD5.Create())
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
