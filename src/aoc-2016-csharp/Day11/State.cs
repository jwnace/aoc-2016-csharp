namespace aoc_2016_csharp.Day11;

public record State(Floor FirstFloor, Floor SecondFloor, Floor ThirdFloor, Floor FourthFloor)
{
    public bool IsValid() =>
        FirstFloor.IsValid() && SecondFloor.IsValid() && ThirdFloor.IsValid() && FourthFloor.IsValid();

    public int ElevatorPosition =>
        FirstFloor.HasElevator() ? 1 : SecondFloor.HasElevator() ? 2 : ThirdFloor.HasElevator() ? 3 : 4;
}
