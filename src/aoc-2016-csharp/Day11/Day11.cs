namespace aoc_2016_csharp.Day11;

public static class Day11
{
    private static readonly string[] Input = File.ReadAllLines("Day11/day11.txt");
    private static readonly List<string[,]> KnownStates = new List<string[,]>();

    public static int Part1()
    {
        // generate the initial state
        var state = new string[,]
        {
            // A = promethium
            // B = cobalt
            // C = curium
            // D = ruthenium
            // E = plutonium
            { "E", "AG", "AM", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " }, // first floor
            { "E", "  ", "  ", "BG", "  ", "CG", "  ", "DG", "  ", "EG", "  " }, // second floor
            { "E", "  ", "  ", "  ", "BM", "  ", "CM", "  ", "DM", "  ", "EM" }, // third floor
            { "E", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " }, // fourth floor
        };

        // run until we have a result, or a set of results?
        state = Run(state);

        return 1;
    }

    private static string[,]? Run(string[,] state)
    {
        // if this is a state we already know about, throw it out
        if (KnownStates.Any(x => AreEquivalent(state, x)))
        {
            return null;
        }
        
        // if this is a state where a microchip gets fried, throw it out
        if (IsInvalidState(state))
        {
            return null;
        }

        // add the current state to the list of known states
        KnownStates.Add(state);

        // TODO: try out all possible moves

        throw new NotImplementedException();
    }

    private static bool AreEquivalent(string[,] a, string[,] b)
    {
        // TODO: implement a comparison to determine if two states are equivalent given that all pairs can be treated the same
        throw new NotImplementedException();
    }

    private static bool IsInvalidState(string[,] state)
    {
        // TODO: check if this state would result in any fried microchips
        throw new NotImplementedException();
    }

    public static int Part2()
    {
        return 2;
    }
}
