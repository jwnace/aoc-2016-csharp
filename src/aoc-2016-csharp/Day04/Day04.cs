using System.Text.RegularExpressions;

namespace aoc_2016_csharp.Day04;

public static class Day04
{
    private record Room(string Name, int SectorId, bool IsRealRoom, string DecryptedName = "");
    private static readonly string[] Input = File.ReadAllLines("Day04/day04.txt");

    public static int Part1()
    {
        var rooms = new List<Room>();

        foreach (var line in Input)
        {
            var temp = line.Split("[");
            var letters = Regex.Match(temp[0].Replace("-", ""), "[a-z]+").Value;
            var checksum = temp[1][..^1];
            var sectorId = int.Parse(Regex.Match(line, "[0-9]+").Value);
            var computedChecksum = ComputeChecksum(letters);
            var isRealRoom = checksum == computedChecksum;

            rooms.Add(new Room(line, sectorId, isRealRoom));
        }

        return rooms.Where(x => x.IsRealRoom).Sum(x => x.SectorId);
    }

    public static int Part2()
    {
        var rooms = new List<Room>();

        foreach (var line in Input)
        {
            var temp = line.Split("[");
            var temp2 = Regex.Replace(temp[0], "[0-9]+", "");
            var letters = Regex.Match(temp[0].Replace("-", ""), "[a-z]+").Value;
            var checksum = temp[1][..^1];
            var sectorId = int.Parse(Regex.Match(line, "[0-9]+").Value);
            var computedChecksum = ComputeChecksum(letters);
            var isRealRoom = checksum == computedChecksum;
            var shift = (char)(sectorId % (char)26);

            var shiftedLetters = "";

            foreach (var c in temp2)
            {
                if (c == '-')
                {
                    shiftedLetters += ' ';
                    continue;
                }

                char shiftedChar = (char)(c + shift);

                if (shiftedChar > (char)122)
                {
                    shiftedChar -= (char)26;
                }

                shiftedLetters += shiftedChar;
            }

            var decryptedName = shiftedLetters.Trim();

            rooms.Add(new Room(line, sectorId, isRealRoom, decryptedName));
        }

        return rooms.Where(x => x.IsRealRoom)
            .Single(x => x.DecryptedName.Contains("north") && x.DecryptedName.Contains("pole") && x.DecryptedName.Contains("object"))
            .SectorId;
    }

    private static string ComputeChecksum(string input)
    {
        var query = input.GroupBy(c => c)
            .Select(g => new { g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .ThenBy(g => g.Key)
            .Select(x => x.Key)
            .Take(5)
            .ToArray();

        return new string(query);
    }
}
