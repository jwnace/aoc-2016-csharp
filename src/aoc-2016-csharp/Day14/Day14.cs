using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day14;

public static class Day14
{
    private static readonly string Input = "cuanljph";
    // private static readonly string Input = "abc";
    private static readonly Dictionary<string, string> Memo = new();

    public static int Part1()
    {
        var count = 0;
        
        for (var i = 0; i < int.MaxValue; i++)
        {
            var isKey = IsKey(Input, i); 
            count += isKey ? 1 : 0;

            if (isKey)
            {
                // Console.WriteLine($"Found Key: {count}");
            }

            if (count == 64)
            {
                return i;
            }
        }
        
        return 0;
    }

    public static int Part2()
    {
        var count = 0;
        
        for (var i = 0; i < int.MaxValue; i++)
        {
            var isKey = IsKeyPart2(Input, i); 
            count += isKey ? 1 : 0;

            if (isKey)
            {
                Console.WriteLine($"Found Key: {count} at index: {i}");
            }

            if (count == 64)
            {
                return i;
            }
        }
        
        return 0;
    }

    private static bool IsKey(string salt, int index)
    {
        var temp = salt + index;
        var md5 = GetHash(temp);
        var match = Regex.Match(md5, @"([a-zA-Z0-9])\1{2}");

        if (!match.Success)
        {
            return false;
        }

        var c = match.Value[0];

        for (var i = 1; i <= 1000; i++)
        {
            var temp2 = salt + (index + i);
            var md52 = GetHash(temp2);
            var pattern2 = @"(" + c + @")\1{4}";
            var match2 = Regex.Match(md52, pattern2);

            if (match2.Success)
            {
                return true;
            }
        }

        return false;
    }
    
    private static bool IsKeyPart2(string salt, int index)
    {
        var temp = salt + index;
        var md5 = GetHash(temp);

        for (var j = 0; j < 2016; j++)
        {
            md5 = GetHash(md5);
        }
        
        var match = Regex.Match(md5, @"([a-zA-Z0-9])\1{2}");

        if (!match.Success)
        {
            return false;
        }

        var c = match.Value[0];

        for (var i = 1; i <= 1000; i++)
        {
            var temp2 = salt + (index + i);
            var md52 = GetHash(temp2);
            
            for (var k = 0; k < 2016; k++)
            {
                md52 = GetHash(md52);
            }
            
            var pattern2 = @"(" + c + @")\1{4}";
            var match2 = Regex.Match(md52, pattern2);

            if (match2.Success)
            {
                return true;
            }
        }

        return false;
    }

    private static string GetHash(string s)
    {
        if (Memo.TryGetValue(s, out var result))
        {
            return result;
        }
        
        var hash = s.ToMd5String();
        Memo[s] = hash;

        return hash;
    }
}
