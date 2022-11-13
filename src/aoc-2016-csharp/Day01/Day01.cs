namespace aoc_2016_csharp.Day01;

public class Day01 : IDay
{
    public string Part1()
    {
        var input = File.ReadAllText($"{GetType().Name}/day01.txt").Split(", ");
        var position = (X: 0, Y: 0);
        var facing = "N";

        foreach (var move in input)
        {
            var direction = move[0].ToString();
            var distance = int.Parse(move.Substring(1));

            if (facing == "N")
            {
                if (direction == "R")
                {
                    facing = "E";
                }
                else if (direction == "L")
                {
                    facing = "W";
                }
            }
            else if (facing == "E")
            {
                if (direction == "R")
                {
                    facing = "S";
                }
                else if (direction == "L")
                {
                    facing = "N";
                }
            }
            else if (facing == "S")
            {
                if (direction == "R")
                {
                    facing = "W";
                }
                else if (direction == "L")
                {
                    facing = "E";
                }
            }
            else if (facing == "W")
            {
                if (direction == "R")
                {
                    facing = "N";
                }
                else if (direction == "L")
                {
                    facing = "S";
                }
            }

            if (facing == "N")
            {
                position.Y += distance;
            }
            else if (facing == "E")
            {
                position.X += distance;
            }
            else if (facing == "S")
            {
                position.Y -= distance;
            }
            else if (facing == "W")
            {
                position.X -= distance;
            }
        }

        var result = Math.Abs(position.X) + Math.Abs(position.Y);
        return result.ToString();
    }

    public string Part2()
    {
        var input = File.ReadAllText($"{GetType().Name}/day01.txt").Split(", ");
        var position = (X: 0, Y: 0);
        var facing = "N";
        var visitedLocations = new List<(int, int)>();

        foreach (var move in input)
        {
            var direction = move[0].ToString();
            var distance = int.Parse(move.Substring(1));

            if (facing == "N")
            {
                if (direction == "R")
                {
                    facing = "E";
                }
                else if (direction == "L")
                {
                    facing = "W";
                }
            }
            else if (facing == "E")
            {
                if (direction == "R")
                {
                    facing = "S";
                }
                else if (direction == "L")
                {
                    facing = "N";
                }
            }
            else if (facing == "S")
            {
                if (direction == "R")
                {
                    facing = "W";
                }
                else if (direction == "L")
                {
                    facing = "E";
                }
            }
            else if (facing == "W")
            {
                if (direction == "R")
                {
                    facing = "N";
                }
                else if (direction == "L")
                {
                    facing = "S";
                }
            }

            if (facing == "N")
            {
                for (int i = 0; i < distance; i++)
                {
                    position.Y++;
                    visitedLocations.Add(position);
                }
            }
            else if (facing == "E")
            {
                for (int i = 0; i < distance; i++)
                {
                    position.X++;
                    visitedLocations.Add(position);
                }
            }
            else if (facing == "S")
            {
                for (int i = 0; i < distance; i++)
                {
                    position.Y--;
                    visitedLocations.Add(position);
                }
            }
            else if (facing == "W")
            {
                for (int i = 0; i < distance; i++)
                {
                    position.X--;
                    visitedLocations.Add(position);
                }
            }
        }

        var query = visitedLocations.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).First(x => x.Count > 1);

        var result = Math.Abs(query.Key.Item1) + Math.Abs(query.Key.Item2);
        return result.ToString();
    }
}
