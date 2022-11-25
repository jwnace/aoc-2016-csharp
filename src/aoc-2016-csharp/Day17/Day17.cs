using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day17;

public static class Day17
{
    private static readonly string Input = File.ReadAllText("Day17/day17.txt");
    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly Queue<State> Queue = new();

    private record State((int X, int Y) Position, string Path)
    {
        public bool IsValid() => Position.X is >= 0 and <= 3 && Position.Y is >= 0 and <= 3;
    }

    public static string Part1() => GetShortestPath(Input);

    public static int Part2() => GetLongestPathLength(Input);

    public static string GetShortestPath(string input)
    {
        Solve(input);
        return Nodes.First(x => x.Key.Position == (3, 3)).Key.Path.Replace(input, "");
    }

    public static int GetLongestPathLength(string input)
    {
        Solve(input);
        return Nodes.Last(x => x.Key.Position == (3, 3)).Key.Path.Replace(input, "").Length;
    }

    private static void Solve(string input)
    {
        // HACK: clear everything at the start to fix unit tests...
        Nodes.Clear();
        Queue.Clear();

        var initialState = new State((0, 0), input);

        Nodes[initialState] = 0;
        Queue.Enqueue(initialState);

        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();
            var neighbors = GetNeighbors(node);

            ProcessNeighbors(neighbors, Nodes[node] + 1);
        }
    }

    private static IEnumerable<State> GetNeighbors(State node)
    {
        var (x, y) = node.Position;
        var open = "bcdef";
        var doors = GetDoorStates(node.Path);
        var n1 = open.Contains(doors[0]) ? new State((x, y - 1), node.Path + 'U') : null;
        var n2 = open.Contains(doors[1]) ? new State((x, y + 1), node.Path + 'D') : null;
        var n3 = open.Contains(doors[2]) ? new State((x - 1, y), node.Path + 'L') : null;
        var n4 = open.Contains(doors[3]) ? new State((x + 1, y), node.Path + 'R') : null;
        var neighbors = new[] { n1, n2, n3, n4 };

        return neighbors.Where(neighbor => neighbor is not null && neighbor.IsValid())!;
    }

    public static string GetDoorStates(string input) => input.ToMd5String()[..4];

    private static void ProcessNeighbors(IEnumerable<State> neighbors, int steps)
    {
        foreach (var neighbor in neighbors)
        {
            if (neighbor.Position == (3, 3))
            {
                Nodes[neighbor] = steps;
                continue;
            }

            Nodes[neighbor] = steps;
            Queue.Enqueue(neighbor);
        }
    }
}
