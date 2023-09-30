namespace aoc_2016_csharp.Day11;

public record State(
    IEnumerable<char> FirstFloor,
    IEnumerable<char> SecondFloor,
    IEnumerable<char> ThirdFloor,
    IEnumerable<char> FourthFloor,
    int ElevatorPosition)
{
    public bool IsValid()
    {
        var floors = new[] { FirstFloor, SecondFloor, ThirdFloor, FourthFloor };
        var generators = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

        var a = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'a') && enumerable.All(y => y != 'A') && enumerable.Any(y => generators.Any(z => z == y));
        });
        var b = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'b') && enumerable.All(y => y != 'B') && enumerable.Any(y => generators.Any(z => z == y));
        });
        var c = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'c') && enumerable.All(y => y != 'C') && enumerable.Any(y => generators.Any(z => z == y));
        });
        var d = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'd') && enumerable.All(y => y != 'D') && enumerable.Any(y => generators.Any(z => z == y));
        });
        var e = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'e') && enumerable.All(y => y != 'E') && enumerable.Any(y => generators.Any(z => z == y));
        });
        var f = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'f') && enumerable.All(y => y != 'F') && enumerable.Any(y => generators.Any(z => z == y));
        });
        var g = floors.Any(x =>
        {
            var enumerable = x as char[] ?? x.ToArray();
            return enumerable.Any(y => y == 'g') && enumerable.All(y => y != 'G') && enumerable.Any(y => generators.Any(z => z == y));
        });

        return !a && !b && !c && !d && !e && !f && !g;
    }
}
