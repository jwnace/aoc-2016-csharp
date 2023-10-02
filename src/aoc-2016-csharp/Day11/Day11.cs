namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private static readonly Dictionary<State, int> Nodes = new();
    private static readonly PriorityQueue<State, int> Queue = new();

    private static readonly int[] Masks =
    {
        0b1_0000000_0000001,
        0b1_0000000_0000010,
        0b1_0000000_0000100,
        0b1_0000000_0001000,
        0b1_0000000_0010000,
        0b1_0000000_0100000,
        0b1_0000000_1000000,
        0b1_0000001_0000000,
        0b1_0000010_0000000,
        0b1_0000100_0000000,
        0b1_0001000_0000000,
        0b1_0010000_0000000,
        0b1_0100000_0000000,
        0b1_1000000_0000000,

        0b1_0000000_0000011,
        0b1_0000000_0000101,
        0b1_0000000_0001001,
        0b1_0000000_0010001,
        0b1_0000000_0100001,
        0b1_0000000_1000001,
        0b1_0000001_0000001,
        0b1_0000010_0000001,
        0b1_0000100_0000001,
        0b1_0001000_0000001,
        0b1_0010000_0000001,
        0b1_0100000_0000001,
        0b1_1000000_0000001,

        0b1_0000000_0000110,
        0b1_0000000_0001010,
        0b1_0000000_0010010,
        0b1_0000000_0100010,
        0b1_0000000_1000010,
        0b1_0000001_0000010,
        0b1_0000010_0000010,
        0b1_0000100_0000010,
        0b1_0001000_0000010,
        0b1_0010000_0000010,
        0b1_0100000_0000010,
        0b1_1000000_0000010,

        0b1_0000000_0001100,
        0b1_0000000_0010100,
        0b1_0000000_0100100,
        0b1_0000000_1000100,
        0b1_0000001_0000100,
        0b1_0000010_0000100,
        0b1_0000100_0000100,
        0b1_0001000_0000100,
        0b1_0010000_0000100,
        0b1_0100000_0000100,
        0b1_1000000_0000100,

        0b1_0000000_0011000,
        0b1_0000000_0101000,
        0b1_0000000_1001000,
        0b1_0000001_0001000,
        0b1_0000010_0001000,
        0b1_0000100_0001000,
        0b1_0001000_0001000,
        0b1_0010000_0001000,
        0b1_0100000_0001000,
        0b1_1000000_0001000,

        0b1_0000000_0110000,
        0b1_0000000_1010000,
        0b1_0000001_0010000,
        0b1_0000010_0010000,
        0b1_0000100_0010000,
        0b1_0001000_0010000,
        0b1_0010000_0010000,
        0b1_0100000_0010000,
        0b1_1000000_0010000,

        0b1_0000000_1100000,
        0b1_0000001_0100000,
        0b1_0000010_0100000,
        0b1_0000100_0100000,
        0b1_0001000_0100000,
        0b1_0010000_0100000,
        0b1_0100000_0100000,
        0b1_1000000_0100000,

        0b1_0000001_1000000,
        0b1_0000010_1000000,
        0b1_0000100_1000000,
        0b1_0001000_1000000,
        0b1_0010000_1000000,
        0b1_0100000_1000000,
        0b1_1000000_1000000,

        0b1_0000011_0000000,
        0b1_0000101_0000000,
        0b1_0001001_0000000,
        0b1_0010001_0000000,
        0b1_0100001_0000000,
        0b1_1000001_0000000,

        0b1_0000110_0000000,
        0b1_0001010_0000000,
        0b1_0010010_0000000,
        0b1_0100010_0000000,
        0b1_1000010_0000000,

        0b1_0001100_0000000,
        0b1_0010100_0000000,
        0b1_0100100_0000000,
        0b1_1000100_0000000,

        0b1_0011000_0000000,
        0b1_0101000_0000000,
        0b1_1001000_0000000,

        0b1_0110000_0000000,
        0b1_1010000_0000000,

        0b1_1100000_0000000,
    };

    public static int Part1()
    {
        var initialState = new State
        (
            new Floor(0b1_0000001_0000001),
            new Floor(0b0_0011110_0000000),
            new Floor(0b0_0000000_0011110),
            new Floor(0b0_0000000_0000000)
        );

        Nodes[initialState] = 0;
        Queue.Enqueue(initialState, 0);

        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();

            if (node.Floor4 == 0b1_0011111_0011111)
            {
                return Nodes[node];
            }

            var neighbors = GetNeighbors(node);

            ProcessNeighbors(neighbors, Nodes[node] + 1);
        }

        return Nodes.First(x => x.Key.Floor4 == 0b1_0011111_0011111).Value;
    }

    public static int Part2()
    {
        // HACK: reset the dictionary because I'm lazy
        Nodes.Clear();
        Queue.Clear();

        var initialState = new State
        (
            new Floor(0b1_1100001_1100001),
            new Floor(0b0_0011110_0000000),
            new Floor(0b0_0000000_0011110),
            new Floor(0b0_0000000_0000000)
        );

        Nodes[initialState] = 0;
        Queue.Enqueue(initialState, 0);

        while (Queue.Count > 0)
        {
            var node = Queue.Dequeue();

            if (node.Floor4 == 0b1_1111111_1111111)
            {
                return Nodes[node];
            }

            var neighbors = GetNeighbors(node);

            ProcessNeighbors(neighbors, Nodes[node] + 1);
        }

        return Nodes.First(x => x.Key.Floor4 == 0b1_1111111_1111111).Value;
    }

    private static IEnumerable<State> GetNeighbors(State node)
    {
        var result = new List<State>();

        // figure out which floor the elevator is on
        var currentFloor = node.ElevatorPosition switch
        {
            1 => node.Floor1,
            2 => node.Floor2,
            3 => node.Floor3,
            4 => node.Floor4,
            _ => throw new InvalidOperationException()
        };

        // get all possible elevator loads from the current floor
        var potentialLoads = Masks.Select(m => currentFloor & m)
            .Where(x => (x & 0b1111111_1111111) > 0)
            .Distinct()
            .ToList();

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

    private static IEnumerable<State> GetNewStates(State node, int newFloor, List<int> potentialLoads)
    {
        foreach (var load in potentialLoads)
        {
            // remove the load from the current floor (by removing it from ALL floors)
            var temp1 = node.Floor1 & ~load;
            var temp2 = node.Floor2 & ~load;
            var temp3 = node.Floor3 & ~load;
            var temp4 = node.Floor4 & ~load;

            // add the load to the new floor
            switch (newFloor)
            {
                case 1:
                    temp1 |= load;
                    temp1 |= 1 << 14;
                    break;
                case 2:
                    temp2 |= load;
                    temp2 |= 1 << 14;
                    break;
                case 3:
                    temp3 |= load;
                    temp3 |= 1 << 14;
                    break;
                case 4:
                    temp4 |= load;
                    temp4 |= 1 << 14;
                    break;
            }

            var newState = new State
            (
                new Floor(temp1),
                new Floor(temp2),
                new Floor(temp3),
                new Floor(temp4)
            );

            if (newState.IsValid())
            {
                yield return newState;
            }
        }
    }

    private static void ProcessNeighbors(IEnumerable<State> neighbors, int steps)
    {
        foreach (var neighbor in neighbors)
        {
            // TODO: figure out how to prune EQUIVALENT states (different pairs in the same pattern)
            if (Nodes.ContainsKey(neighbor))
            {
                continue;
            }

            Nodes[neighbor] = steps;
            Queue.Enqueue(neighbor, steps);
        }
    }
}
