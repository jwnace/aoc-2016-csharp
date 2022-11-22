namespace aoc_2016_csharp.Day13;

public static class Day13
{
    private static readonly long Input = 1362;
    private static readonly Dictionary<(int, int), int> Nodes = new();
    private static readonly PriorityQueue<(int, int), int> Queue = new();

    public static long Part1()
    {
        Dijkstra(1, 1);

        return Nodes[(31, 39)];
    }

    public static long Part2()
    {
        Dijkstra(1, 1);

        return Nodes.Count(x => x.Value <= 50);
    }

    private static void Dijkstra(int startX, int startY)
    {
        Queue.Enqueue((startX, startY), 0);
        Nodes[(startX, startY)] = 0;
        
        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();
            var (x, y) = node;
            var n1 = (x - 1, y);
            var n2 = (x + 1, y);
            var n3 = (x, y - 1);
            var n4 = (x, y + 1);
            var neighbors = new List<(int, int)> { n1, n2, n3, n4 };

            foreach (var neighbor in neighbors)
            {
                var (nx, ny) = neighbor;

                if (nx < 0 || ny < 0 || IsWall(nx, ny))
                {
                    continue;
                }

                var d = Nodes[node] + 1;

                if (!Nodes.TryGetValue(neighbor, out var nd) || d < nd)
                {
                    Nodes[neighbor] = d;
                    Queue.Enqueue(neighbor, d);
                }
            }
        }
    }

    private static bool IsWall(long x, long y)
    {
        var temp = (x * x) + (3 * x) + (2 * x * y) + y + (y * y) + Input;

        var binaryString = Convert.ToString(temp, 2);

        return binaryString.Count(c => c == '1') % 2 != 0;
    }
}
