using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly Queue<State> Queue = new();

    private record State(string FirstFloor, string SecondFloor, string ThirdFloor, string FourthFloor, int ElevatorPosition)
    {
        public bool IsValid()
        {
            var floors = new[] { FirstFloor, SecondFloor, ThirdFloor, FourthFloor };
            var generators = "ABCDEFG";

            var a = floors.Any(x => x.Contains("a") && !x.Contains("A") && x.Any(y => generators.Contains(y)));
            var b = floors.Any(x => x.Contains("b") && !x.Contains("B") && x.Any(y => generators.Contains(y)));
            var c = floors.Any(x => x.Contains("c") && !x.Contains("C") && x.Any(y => generators.Contains(y)));
            var d = floors.Any(x => x.Contains("d") && !x.Contains("D") && x.Any(y => generators.Contains(y)));
            var e = floors.Any(x => x.Contains("e") && !x.Contains("E") && x.Any(y => generators.Contains(y)));
            var f = floors.Any(x => x.Contains("f") && !x.Contains("F") && x.Any(y => generators.Contains(y)));
            var g = floors.Any(x => x.Contains("g") && !x.Contains("G") && x.Any(y => generators.Contains(y)));

            return !a && !b && !c && !d && !e && !f && !g;
        }
    }

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
        // HACK: reset the dictionary because I'm lazy
        Nodes.Clear();
        Queue.Clear();

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

    private static IEnumerable<State> GetNeighbors(State node)
    {
        var result = new List<State>();

        // figure out which floor the elevator is on
        var currentFloor = node.ElevatorPosition switch
        {
            1 => node.FirstFloor,
            2 => node.SecondFloor,
            3 => node.ThirdFloor,
            4 => node.FourthFloor,
            _ => throw new InvalidOperationException()
        };

        // get all possible elevator loads from the current floor
        var potentialLoads = currentFloor.GetCombinations(2).Concat(currentFloor.GetCombinations(1));

        // move the elevator up if possible
        if (node.ElevatorPosition < 4)
        {
            // build a new state, set its distance, and add it to the queue
            var newStates = GetNewStates(node, node.ElevatorPosition + 1, potentialLoads);
            result.AddRange(newStates);
        }

        // move the elevator down
        if (node.ElevatorPosition > 1)
        {
            // build a new state, set its distance, and add it to the queue
            var newStates = GetNewStates(node, node.ElevatorPosition - 1, potentialLoads);
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

            // remove the load from the current floor (by removing it from ALL floors)
            var q1 = floors.Select(x => new string(x?.Except(load).ToArray()));

            // add the load to the new floor, and sort the values on the new floor alphabetically
            var q2 = q1.Select((x, i) => i == newFloor ? new string(x?.Concat(load).OrderBy(c => c).ToArray()) : x).ToArray();

            var newState = node with
            {
                ElevatorPosition = newFloor,
                FirstFloor = q2[1],
                SecondFloor = q2[2],
                ThirdFloor = q2[3],
                FourthFloor = q2[4],
            };

            result.Add(newState);
        }

        return result;
    }

    private static void ProcessNeighbors(IEnumerable<State> neighbors, int steps)
    {
        foreach (var neighbor in neighbors)
        {
            if (Nodes.TryGetValue(neighbor, out _) || !neighbor.IsValid())
            {
                continue;
            }

            Nodes[neighbor] = steps;
            Queue.Enqueue(neighbor);
        }
    }
}
