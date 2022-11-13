namespace aoc_2016_csharp.Day01;

public static class Day01
{
    private static readonly string[] Input = File.ReadAllText("Day01/day01.txt").Split(", ");

    public static int Part1()
    {
        var position = (X: 0, Y: 0);
        var direction = "N";

        foreach (var move in Input)
        {
            var turn = move[0].ToString();
            var distance = int.Parse(move[1..]);

            direction = Turn(direction, turn);
            position = Move(direction, position, distance);
        }

        return Math.Abs(position.X) + Math.Abs(position.Y);
    }

    public static int Part2()
    {
        var visitedLocations = new List<(int X, int Y)>();
        var position = (X: 0, Y: 0);
        var direction = "N";

        foreach (var move in Input)
        {
            var turn = move[0].ToString();
            var distance = int.Parse(move[1..]);

            direction = Turn(direction, turn);
            position = Move(direction, position, distance, visitedLocations);
        }

        var destination = visitedLocations.GroupBy(x => x).Select(g => new { Position = g.Key, Count = g.Count() }).First(x => x.Count > 1).Position;
        return Math.Abs(destination.X) + Math.Abs(destination.Y);
    }

    private static string Turn(string direction, string turn) =>
        (direction, turn) switch
        {
            ("N", "R") => "E",
            ("N", "L") => "W",
            ("E", "R") => "S",
            ("E", "L") => "N",
            ("S", "R") => "W",
            ("S", "L") => "E",
            ("W", "R") => "N",
            ("W", "L") => "S",
            _ => throw new ArgumentOutOfRangeException()
        };

    private static (int X, int Y) Move(string direction, (int X, int Y) position, int distance) =>
        direction switch
        {
            "N" => (position.X, position.Y + distance),
            "E" => (position.X + distance, position.Y),
            "S" => (position.X, position.Y - distance),
            "W" => (position.X - distance, position.Y),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    private static (int X, int Y) Move(string direction, (int X, int Y) position, int distance, ICollection<(int X, int Y)> visitedLocations)
    {
        for (var i = 0; i < distance; i++)
        {
            position = direction switch
            {
                "N" => (position.X, position.Y + 1),
                "E" => (position.X + 1, position.Y),
                "S" => (position.X, position.Y - 1),
                "W" => (position.X - 1, position.Y),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

            visitedLocations.Add(position);
        }

        return position;
    }
}
