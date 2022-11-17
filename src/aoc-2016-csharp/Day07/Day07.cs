using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day07;

public static class Day07
{
    private static readonly string[] Input = File.ReadAllLines("Day07/day07.txt");

    public static int Part1() => Input.Select(x => new IpAddress(x)).Count(x => x.SupportsTls);

    public static int Part2() => Input.Select(x => new IpAddress(x)).Count(x => x.SupportsSsl);

    private record IpAddress
    {
        private readonly List<string> _unbracketedSections;
        private readonly List<string> _bracketedSections;

        public bool SupportsTls => _unbracketedSections.Any(ContainsAbba) && !_bracketedSections.Any(ContainsAbba);

        public bool SupportsSsl => GetAbas(_unbracketedSections)
            .Select(aba => "" + aba[1] + aba[0] + aba[1])
            .Any(bab => _bracketedSections.Any(x => x.Contains(bab)));

        public IpAddress(string address) => (_bracketedSections, _unbracketedSections) = GetSections(address);

        private static (List<string> BracketedStrings, List<string> UnbracketedStrings) GetSections(string line)
        {
            var bracketedStrings = new List<string>();
            var unbracketedStrings = new List<string>();
            var buffer = "";

            foreach (var c in line)
            {
                switch (c)
                {
                    case '[':
                        unbracketedStrings.Add(buffer);
                        buffer = "";
                        break;
                    case ']':
                        bracketedStrings.Add(buffer);
                        buffer = "";
                        break;
                    default:
                        buffer += c;
                        break;
                }
            }

            if (buffer.Length > 0)
            {
                unbracketedStrings.Add(buffer);
            }

            return (bracketedStrings, unbracketedStrings);
        }

        private static bool ContainsAbba(string input) => input.Slice(4).Any(x => x[0] == x[3] && x[1] == x[2] && x[0] != x[1]);

        private static IEnumerable<string> GetAbas(IEnumerable<string> unbracketedStrings) =>
            unbracketedStrings.SelectMany(x => x.Slice(3)).Where(x => x[0] == x[2] && x[0] != x[1]).Distinct();
    }
}
