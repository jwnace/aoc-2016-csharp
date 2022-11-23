using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private record State(string FirstFloor, string SecondFloor, string ThirdFloor, string FourthFloor, int Elevator)
    {
        public bool IsValid()
        {
            var floors = new[] { FirstFloor, SecondFloor, ThirdFloor, FourthFloor };
            var generators = "ABCDEFG";

            var q1 = floors.Any(x => x.Contains("a") && !x.Contains("A") && x.Any(y => generators.Contains(y)));
            var q2 = floors.Any(x => x.Contains("b") && !x.Contains("B") && x.Any(y => generators.Contains(y)));
            var q3 = floors.Any(x => x.Contains("c") && !x.Contains("C") && x.Any(y => generators.Contains(y)));
            var q4 = floors.Any(x => x.Contains("d") && !x.Contains("D") && x.Any(y => generators.Contains(y)));
            var q5 = floors.Any(x => x.Contains("e") && !x.Contains("E") && x.Any(y => generators.Contains(y)));
            var q6 = floors.Any(x => x.Contains("f") && !x.Contains("F") && x.Any(y => generators.Contains(y)));
            var q7 = floors.Any(x => x.Contains("g") && !x.Contains("G") && x.Any(y => generators.Contains(y)));

            return !q1 && !q2 && !q3 && !q4 && !q5 && !q6 && !q7;
        }
    }

    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly Queue<State> Queue = new();

    public static int Part1()
    {
        var initialState = new State
        (
            "aA",
            "BCDE",
            "bcde",
            "",
            1
        );

        Nodes[initialState] = 0;
        Queue.Enqueue(initialState);

        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();
            var neighbors = GetNeighbors(node);

            ProcessNeighbors(neighbors, Nodes[node] + 1);
        }

        return Nodes.First(x => x.Key.FourthFloor.Length == 10).Value;
    }

    public static int Part2()
    {
        var initialState = new State
        (
            "AFGafg",
            "BCDE",
            "bcde",
            "",
            1
        );

        Nodes[initialState] = 0;
        Queue.Enqueue(initialState);

        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();
            var neighbors = GetNeighbors(node);

            ProcessNeighbors(neighbors, Nodes[node] + 1);
        }

        return Nodes.First(x => x.Key.FourthFloor.Length == 14).Value;
    }

    private static void ProcessNeighbors(IEnumerable<State> nodes, int steps)
    {
        foreach (var node in nodes)
        {
            if (Nodes.TryGetValue(node, out _) || !node.IsValid())
            {
                continue;
            }

            Nodes[node] = steps;
            Queue.Enqueue(node);
        }
    }

    private static IEnumerable<State> GetNeighbors(State node)
    {
        var result = new List<State>();

        // figure out which floor the elevator is on
        var currentFloor = node.Elevator;

        var currentFloorString = currentFloor switch
        {
            1 => node.FirstFloor,
            2 => node.SecondFloor,
            3 => node.ThirdFloor,
            4 => node.FourthFloor,
            _ => throw new InvalidOperationException()
        };

        var potentialLoads = currentFloorString.GetCombinations(2).Concat(currentFloorString.GetCombinations(1));

        // move the elevator up if possible
        if (currentFloor < 4)
        {
            // build a new state, set its distance, and add it to the queue
            var newStates = GetNewStates(node, currentFloor + 1, potentialLoads);
            result.AddRange(newStates);
        }

        // move the elevator down
        if (currentFloor > 1)
        {
            // build a new state, set its distance, and add it to the queue
            var newStates = GetNewStates(node, currentFloor - 1, potentialLoads);
            result.AddRange(newStates);
        }

        return result;
    }

    private static IEnumerable<State> GetNewStates(State node, int newFloor, IEnumerable<IEnumerable<char>> potentialLoads)
    {
        var result = new List<State>();

        foreach (var load in potentialLoads)
        {
            var floors = new[] { null, node.FirstFloor, node.SecondFloor, node.ThirdFloor, node.FourthFloor };
            var query1 = floors.Select(x => new string(x?.Except(load).ToArray()));
            var query2 = query1.Select((x, i) => i == newFloor ? new string(x?.Concat(load).OrderBy(c => c).ToArray()) : x).ToArray();

            var newState = node with
            {
                Elevator = newFloor,
                FirstFloor = query2[1],
                SecondFloor = query2[2],
                ThirdFloor = query2[3],
                FourthFloor = query2[4],
            };

            result.Add(newState);
        }

        return result;
    }
}
