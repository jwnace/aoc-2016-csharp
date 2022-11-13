namespace aoc_2016_csharp.Day03;

public static class Day03
{
    public static int Part1()
    {
        var triangles = File.ReadAllLines("Day03/day03.txt")
            .Select(x => x.Split(null).Where(y => !string.IsNullOrWhiteSpace(y)).Select(int.Parse));

        return triangles.Count(IsValidTriangle);
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("Day03/day03.txt");
        var triangles = new List<List<int>>();
        var triangle1 = new List<int>();
        var triangle2 = new List<int>();
        var triangle3 = new List<int>();

        foreach (var line in input)
        {
            var sides = line.Split(null).Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();

            triangle1.Add(sides[0]);
            triangle2.Add(sides[1]);
            triangle3.Add(sides[2]);

            if (triangle1.Count == 3)
            {
                triangles.Add(triangle1);
                triangles.Add(triangle2);
                triangles.Add(triangle3);
                triangle1 = new List<int>();
                triangle2 = new List<int>();
                triangle3 = new List<int>();
            }
        }

        return triangles.Count(IsValidTriangle);
    }

    private static bool IsValidTriangle(IEnumerable<int> triangle)
    {
        var t = triangle as int[] ?? triangle.ToArray();
        var (a, b, c) = (t[0], t[1], t[2]);
        return a + b > c && a + c > b && b + c > a;
    }
}
