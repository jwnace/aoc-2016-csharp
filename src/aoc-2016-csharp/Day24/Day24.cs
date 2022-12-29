namespace aoc_2016_csharp.Day24;

public static class Day24
{
    private static readonly string[] Input = File.ReadAllLines("Day24/day24.txt");

    public static int Part1() => GetShortestPath(false);

    public static int Part2() => GetShortestPath(true);

    private static int GetShortestPath(bool destinationMatters)
    {
        var grid = BuildGrid();
        var startingPosition = grid.First(x => x.Value == '0').Key;
        var destination = startingPosition;
        var (startRow, startCol) = startingPosition;
        var initialState = (startRow, startCol, false, false, false, false, false, false, false);

        var queue = new Queue<(int Row, int Col, bool HasReached1, bool HasReached2, bool HasReached3,
            bool HasReached4, bool HasReached5, bool HasReached6, bool HasReached7)>();
        queue.Enqueue(initialState);

        var distances = new Dictionary<(int, int, bool, bool, bool, bool, bool, bool, bool), int>();
        distances[initialState] = 0;

        var seen = new HashSet<(int, int, bool, bool, bool, bool, bool, bool, bool)>();

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();

            if (seen.Contains(state))
            {
                continue;
            }

            seen.Add(state);

            var (row, col, hasReached1, hasReached2, hasReached3, hasReached4, hasReached5, hasReached6, hasReached7) =
                state;

            var value = grid.TryGetValue((row, col), out var c) ? c : ' ';

            switch (value)
            {
                case '1':
                    hasReached1 = true;
                    break;
                case '2':
                    hasReached2 = true;
                    break;
                case '3':
                    hasReached3 = true;
                    break;
                case '4':
                    hasReached4 = true;
                    break;
                case '5':
                    hasReached5 = true;
                    break;
                case '6':
                    hasReached6 = true;
                    break;
                case '7':
                    hasReached7 = true;
                    break;
            }

            // for part 1, we don't care where we end up
            if (!destinationMatters && hasReached1 && hasReached2 && hasReached3 && hasReached4 && hasReached5 &&
                hasReached6 && hasReached7)
            {
                return distances[state];
            }

            // for part 2, we want to end up back at the start
            if (destinationMatters && (row, col) == destination && hasReached1 && hasReached2 && hasReached3 &&
                hasReached4 && hasReached5 && hasReached6 && hasReached7)
            {
                return distances[state];
            }

            var neighbors = new[]
            {
                (Row: row - 1, Col: col),
                (Row: row + 1, Col: col),
                (Row: row, Col: col - 1),
                (Row: row, Col: col + 1)
            };

            foreach (var neighbor in neighbors)
            {
                if (grid.ContainsKey(neighbor) && grid[neighbor] == '#')
                {
                    continue;
                }

                var nextState = (neighbor.Row, neighbor.Col, hasReached1, hasReached2, hasReached3, hasReached4,
                    hasReached5, hasReached6, hasReached7);

                distances[nextState] = distances[state] + 1;
                queue.Enqueue(nextState);
            }
        }

        throw new Exception("couldn't find a solution!");
    }

    private static Dictionary<(int Row, int Col), char> BuildGrid()
    {
        var grid = new Dictionary<(int Row, int Col), char>();

        for (var i = 0; i < Input.Length; i++)
        {
            for (var j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] != '.')
                {
                    grid[(i, j)] = Input[i][j];
                }
            }
        }

        return grid;
    }
}
