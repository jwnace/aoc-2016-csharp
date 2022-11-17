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
}
