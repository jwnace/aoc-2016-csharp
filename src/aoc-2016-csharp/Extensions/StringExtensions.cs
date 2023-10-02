using System.Security.Cryptography;
using System.Text;

namespace aoc_2016_csharp.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Breaks up a string into overlapping slices of a given size.
    /// </summary>
    /// <param name="input">The input string to be sliced.</param>
    /// <param name="size">The desired size of the individual slices.</param>
    /// <returns>Overlapping slices of the input string of the requested size.</returns>
    public static IEnumerable<string> Slice(this string input, int size)
    {
        for (var i = 0; i < input.Length - size + 1; i++)
        {
            yield return new string(input.Skip(i).Take(4).ToArray());
        }
    }

    /// <summary>
    /// Generates an MD5 hash for a given input string.
    /// </summary>
    /// <param name="input">The input string to be hashed.</param>
    /// <returns>A new string representing the MD5 hash of the input string.</returns>
    public static string ToMd5String(this string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes).ToLower();
    }
}
