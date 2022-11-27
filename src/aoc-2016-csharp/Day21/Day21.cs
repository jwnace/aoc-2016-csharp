using System.Text;
using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day21;

public static class Day21
{
    public static readonly string[] Input = File.ReadAllLines("Day21/day21.txt");

    public static string Part1() => Scramble("abcdefgh");

    public static string Part2() => Unscramble("fbgdceah");

    public static string Scramble(string password)
    {
        var builder = new StringBuilder(password);

        foreach (var line in Input)
        {
            // swap position X with position Y
            // swap letter X with letter Y
            // rotate left/right X steps
            // rotate based on position of letter X
            // reverse positions X through Y
            // move position X to position Y

            var values = line.Split(' ');

            if (values[0] == "swap")
            {
                if (values[1] == "position")
                {
                    var (x, y) = (int.Parse(values[2]), int.Parse(values[5]));
                    (builder[x], builder[y]) = (builder[y], builder[x]);
                }
                else if (values[1] == "letter")
                {
                    var (x, y) = (values[2], values[5]);
                    builder.Replace(x, "_");
                    builder.Replace(y, x);
                    builder.Replace("_", y);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (values[0] == "rotate")
            {
                if (values[1] == "left")
                {
                    var x = int.Parse(values[2]);
                    var buffer = new char[builder.Length];

                    for (var i = 0; i < builder.Length; i++)
                    {
                        var index = (i + x) % builder.Length;
                        buffer[i] = builder[index];
                    }

                    builder.Clear();
                    builder.Append(buffer);
                }
                else if (values[1] == "right")
                {
                    var x = int.Parse(values[2]);
                    var buffer = new char[builder.Length];

                    for (var i = 0; i < builder.Length; i++)
                    {
                        var index = (i - x) % builder.Length;

                        if (index < 0)
                        {
                            index += builder.Length;
                        }

                        buffer[i] = builder[index];
                    }

                    builder.Clear();
                    builder.Append(buffer);
                }
                else if (values[1] == "based")
                {
                    var letters = new char[builder.Length];
                    var letter = values[6];
                    builder.CopyTo(0, letters, 0, builder.Length);

                    // var q1 = letters
                    // .Where(c => c.ToString() == letter)
                    // .Select((_, i) => i)
                    // .FirstOrDefault();

                    var q2 = letters
                        .Select((c, i) => new { Letter = c.ToString(), Index = i })
                        .FirstOrDefault(c => c.Letter == letter)!
                        .Index;

                    var x = 1 + q2 + (q2 >= 4 ? 1 : 0);

                    // if (q1 != q2)
                    // {
                    // throw new InvalidOperationException("q1 and q2 are different!");
                    // }

                    var buffer = new char[builder.Length];

                    for (var i = 0; i < builder.Length; i++)
                    {
                        var index = (i - x) % builder.Length;

                        if (index < 0)
                        {
                            index += builder.Length;
                        }

                        buffer[i] = builder[index];
                    }

                    builder.Clear();
                    builder.Append(buffer);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (values[0] == "reverse")
            {
                var (x, y) = (int.Parse(values[2]), int.Parse(values[4]));

                while (y > x)
                {
                    (builder[x], builder[y]) = (builder[y], builder[x]);
                    x++;
                    y--;
                }
            }
            else if (values[0] == "move")
            {
                var (x, y) = (int.Parse(values[2]), int.Parse(values[5]));
                var c = builder[x];
                builder.Remove(x, 1);
                builder.Insert(y, c);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        return builder.ToString();
    }

    public static string Unscramble(string password)
    {
        var permutations = password.GetPermutations(password.Length);

        foreach (var p in permutations)
        {
            var permutation = new string(p.ToArray());

            if (password == Scramble(permutation))
            {
                return permutation;
            }
        }

        return "not found";
    }
}
