using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day17;

public static class Day17
{
    private static readonly string Input = File.ReadAllText("Day17/day17.txt");
    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly Queue<State> Queue = new();

    private record State((int X, int Y) Position, string Path)
    {
        public bool IsValid()
        {
            var (x, y) = Position;

            if (x < 0 || x > 3 || y < 0 || y > 3)
            {
                return false;
            }

            return true;
        }
    }

    public static string Part1() => Bar(Input);

    public static string Part2() => Bar(Input);

    public static string Foo(string input)
    {
        return input.ToMd5String()[..4];
    }

    public static string Bar(string input)
    {
        var initialState = new State((0, 0), input);

        Nodes[initialState] = 0;
        Queue.Enqueue(initialState);

        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();
            var neighbors = GetNeighbors(node);

            ProcessNeighbors(neighbors, Nodes[node] + 1);
        }

        return Nodes.Single(x => x.Key.Position == (3, 3)).Key.Path.Replace(input, "");
    }

    private static IEnumerable<State> GetNeighbors(State node)
    {
        var (x, y) = node.Position;

        var open = "bcdef";
        var foo = Foo(node.Path);

        var n3 = open.Contains(foo[0]) ? new State((x, y - 1), node.Path + 'U') : null;
        var n4 = open.Contains(foo[1]) ? new State((x, y + 1), node.Path + 'D') : null;
        var n1 = open.Contains(foo[2]) ? new State((x - 1, y), node.Path + 'L') : null;
        var n2 = open.Contains(foo[3]) ? new State((x + 1, y), node.Path + 'R') : null;

        var neighbors = new [] { n1, n2, n3, n4 };

        return neighbors.Where(neighbor => neighbor is not null && neighbor.IsValid())!;
    }

    private static void ProcessNeighbors(IEnumerable<State> neighbors, int steps)
    {
        foreach (var neighbor in neighbors)
        {
            if (Nodes.Any(x => x.Key.Position == neighbor.Position))
            {
                continue;
            }

            Nodes[neighbor] = steps;
            Queue.Enqueue(neighbor);
        }
    }
}
