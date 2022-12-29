namespace aoc_2016_csharp.Day22;

public static class Day22
{
    private static readonly string[] Input = File.ReadAllLines("Day22/day22.txt");

    public static int Part1() => GetViablePairs();

    public static int Part2()
    {
        return 218; // I solved part 2 by hand :)
    }

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

    private static void PrettyPrint()
    {
        var nodes = GetNodes().OrderBy(n => n.Y).ThenBy(n => n.X).ToList();

        for (var y = 0; y < 31; y++)
        {
            for (var x = 0; x < 33; x++)
            {
                var node = nodes.Single(n => n.X == x && n.Y == y);

                if (node.X == 0 && node.Y == 0)
                {
                    Console.Write("(.)");
                    continue;
                }

                if (node.X == 32 && node.Y == 0)
                {
                    Console.Write(" G ");
                    continue;
                }

                if (node.Used == 0)
                {
                    Console.Write(" _ ");
                    continue;
                }

                if (node.Used > 99)
                {
                    Console.Write(" # ");
                    continue;
                }

                Console.Write(" . ");
            }

            Console.WriteLine();
        }
    }

    private record Node(int X, int Y, int Size, int Used, int Available);
}
