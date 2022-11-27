namespace aoc_2016_csharp.Day22;

public static class Day22
{
    private static readonly string[] Input = File.ReadAllLines("Day22/day22.txt");

    public static int Part1() => GetViablePairs();

    public static int Part2() => 2;

    private static int GetViablePairs()
    {
        var nodes = GetNodes();

        var count = 0;

        foreach (var a in nodes)
        {
            if (a.Used == 0)
            {
                continue;
            }

            foreach (var b in nodes)
            {
                if (a == b)
                {
                    continue;
                }

                if (a.Used <= b.Available)
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static List<Node> GetNodes()
    {
        var query = Input.Skip(2).Select(x => x.Split(null).Where(y => !string.IsNullOrWhiteSpace(y)).ToList()).ToList();
        var nodes = new List<Node>();

        foreach (var node in query)
        {
            var name = node[0];
            var size = int.Parse(node[1][..^1]);
            var used = int.Parse(node[2][..^1]);
            var available = int.Parse(node[3][..^1]);
            var usePercentage = int.Parse(node[4][..^1]);

            var coords = name.Split('-');
            var x = int.Parse(coords[^2][1..]);
            var y = int.Parse(coords[^1][1..]);

            nodes.Add(new Node(x, y, size, used, available));
        }

        return nodes;
    }

    private record Node(int X, int Y, int Size, int Used, int Available);
}
