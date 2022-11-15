using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace aoc_2016_csharp.Day04;

public static class Day04
{
    private static readonly string[] Input = File.ReadAllLines("Day04/day04.txt");

    public static int Part1() => GetRooms()
        .Where(x => x.IsRealRoom)
        .Sum(x => x.SectorId);

    public static int Part2() => GetRooms()
        .Where(x => x.IsRealRoom)
        .Single(x => x.DecryptedName.Contains("northpole"))
        .SectorId;

    private static IEnumerable<Room> GetRooms() => Input.Select(Room.FromString);

    private record Room(string Name, int SectorId, bool IsRealRoom, string DecryptedName)
    {
        public static Room FromString(string input)
        {
            var parts = input.Split("[");
            var letters = Regex.Match(parts[0].Replace("-", ""), "[a-z]+").Value;
            var checksum = parts[1][..^1];
            var sectorId = int.Parse(Regex.Match(input, "[0-9]+").Value);
            var computedChecksum = ComputeChecksum(letters);
            var isRealRoom = checksum == computedChecksum;
            var decryptedName = GetDecryptedName(sectorId, input);

            return new Room(input, sectorId, isRealRoom, decryptedName);
        }

        private static string ComputeChecksum(string input) =>
            new string(input.GroupBy(c => c)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Key)
                .Select(x => x.Key)
                .Take(5)
                .ToArray());

        private static string GetDecryptedName(int sectorId, string name)
        {
            var shift = (char)(sectorId % (char)26);
            var shiftedLetters = "";

            foreach (var c in name)
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

            return shiftedLetters.Trim();
        }
    }
}
