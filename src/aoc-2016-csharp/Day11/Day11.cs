using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly Queue<State> Queue = new();

    private record State(Floor FirstFloor, Floor SecondFloor, Floor ThirdFloor, Floor FourthFloor, int ElevatorPosition)
    {
        public bool IsValid()
        {
            var floors = new[] { FirstFloor, SecondFloor, ThirdFloor, FourthFloor };

            var a = floors.Any(x => x.HasMicrochipA() && !x.HasGeneratorA() && x.HasGenerator());
            var b = floors.Any(x => x.HasMicrochipB() && !x.HasGeneratorB() && x.HasGenerator());
            var c = floors.Any(x => x.HasMicrochipC() && !x.HasGeneratorC() && x.HasGenerator());
            var d = floors.Any(x => x.HasMicrochipD() && !x.HasGeneratorD() && x.HasGenerator());
            var e = floors.Any(x => x.HasMicrochipE() && !x.HasGeneratorE() && x.HasGenerator());
            var f = floors.Any(x => x.HasMicrochipF() && !x.HasGeneratorF() && x.HasGenerator());
            var g = floors.Any(x => x.HasMicrochipG() && !x.HasGeneratorG() && x.HasGenerator());

            return !a && !b && !c && !d && !e && !f && !g;
        }
    }

    private record Floor(string FloorState)
    {
        public bool HasMicrochipA() => FloorState.Contains("a");
        public bool HasMicrochipB() => FloorState.Contains("b");
        public bool HasMicrochipC() => FloorState.Contains("c");
        public bool HasMicrochipD() => FloorState.Contains("d");
        public bool HasMicrochipE() => FloorState.Contains("e");
        public bool HasMicrochipF() => FloorState.Contains("f");
        public bool HasMicrochipG() => FloorState.Contains("g");

        public bool HasGeneratorA() => FloorState.Contains("A");
        public bool HasGeneratorB() => FloorState.Contains("B");
        public bool HasGeneratorC() => FloorState.Contains("C");
        public bool HasGeneratorD() => FloorState.Contains("D");
        public bool HasGeneratorE() => FloorState.Contains("E");
        public bool HasGeneratorF() => FloorState.Contains("F");
        public bool HasGeneratorG() => FloorState.Contains("G");

        public bool HasGenerator() => FloorState.Any(char.IsUpper);
    }

    public static int Part1()
    {
        var initialState = new State
        (
            new Floor("aA"),
            new Floor("BCDE"),
            new Floor("bcde"),
            new Floor(""),
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

        return Nodes.First(x => x.Key.FourthFloor.FloorState.Length == 10).Value;
    }

    public static int Part2()
    {
        // HACK: reset the dictionary because I'm lazy
        Nodes.Clear();
        Queue.Clear();

        var initialState = new State
        (
            new Floor("AFGafg"),
            new Floor("BCDE"),
            new Floor("bcde"),
            new Floor(""),
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

        return Nodes.First(x => x.Key.FourthFloor.FloorState.Length == 14).Value;
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
        var potentialLoads = currentFloor.FloorState.GetCombinations(2)
            .Concat(currentFloor.FloorState.GetCombinations(1));

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
            var q1 = floors.Select(x => new string(x?.FloorState.Except(load).ToArray()));

            // add the load to the new floor, and sort the values on the new floor alphabetically
            var q2 = q1.Select((x, i) => i == newFloor ? new string(x?.Concat(load).OrderBy(c => c).ToArray()) : x).ToArray();

            var newState = node with
            {
                ElevatorPosition = newFloor,
                FirstFloor = new Floor(q2[1]),
                SecondFloor = new Floor(q2[2]),
                ThirdFloor = new Floor(q2[3]),
                FourthFloor = new Floor(q2[4]),
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
