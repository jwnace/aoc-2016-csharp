using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly Queue<State> Queue = new();

    public static int Part1()
    {
        var initialState = new State
        (
            new[] { 'a', 'A' },
            new[] { 'B', 'C', 'D', 'E' },
            new[] { 'b', 'c', 'd', 'e' },
            Array.Empty<char>(),
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

        return Nodes.First(x => x.Key.FourthFloor.Count() == 10).Value;
    }

    public static int Part2()
    {
        // HACK: reset the dictionary because I'm lazy
        Nodes.Clear();
        Queue.Clear();

        var initialState = new State
        (
            new[] { 'A', 'F', 'G', 'a', 'f', 'g' },
            new[] { 'B', 'C', 'D', 'E' },
            new[] { 'b', 'c', 'd', 'e' },
            Array.Empty<char>(),
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

        return Nodes.First(x => x.Key.FourthFloor.Count() == 14).Value;
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
        var enumerable = currentFloor as char[] ?? currentFloor.ToArray();
        var potentialLoads = enumerable.GetCombinations(2).Concat(enumerable.GetCombinations(1));

        // move the elevator up if possible
        var loads = potentialLoads as IEnumerable<char>[] ?? potentialLoads.ToArray();
        if (node.ElevatorPosition < 4)
        {
            // build a new state, set its distance, and add it to the queue
            var newStates = GetNewStates(node, node.ElevatorPosition + 1, loads);
            result.AddRange(newStates);
        }

        // move the elevator down
        if (node.ElevatorPosition > 1)
        {
            // build a new state, set its distance, and add it to the queue
            var newStates = GetNewStates(node, node.ElevatorPosition - 1, loads);
            result.AddRange(newStates);
        }

        return result;
    }

    private static IEnumerable<State> GetNewStates(State node, int newFloor,
        IEnumerable<IEnumerable<char>> potentialLoads)
    {
        var result = new List<State>();

        foreach (var load in potentialLoads)
        {
            var floors = new[]
            {
                Array.Empty<char>(),
                node.FirstFloor,
                node.SecondFloor,
                node.ThirdFloor,
                node.FourthFloor
            };

            // remove the load from the current floor (by removing it from ALL floors)
            var q1 = floors.Select(floor => floor.Except(load));

            // add the load to the new floor, and sort the values on the new floor alphabetically
            var q2 = q1.Select((x, i) => i == newFloor ? x.Concat(load).OrderBy(c => c) : x);

            var enumerable = q2 as IEnumerable<char>[] ?? q2.ToArray();
            var newState = new State(
                ElevatorPosition: newFloor,
                FirstFloor: enumerable.ElementAt(1),
                SecondFloor: enumerable.ElementAt(2),
                ThirdFloor: enumerable.ElementAt(3),
                FourthFloor: enumerable.ElementAt(4));

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
