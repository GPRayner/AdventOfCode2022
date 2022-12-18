using Xunit.Abstractions;

namespace AdventOfCode2022;

public class Day2
{
    private readonly ITestOutputHelper _testOutputHelper;
    private const string Rock = "R";
    private const string Paper = "P";
    private const string Scissors = "S";
    private const int Win = 6;
    private const int Draw = 3;
    private const int Lose = 0;

    public Day2(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Example()
    {
        var input = File.ReadLines("Day2/example.txt");
        var score = Part1(input);
        Assert.Equal(15, score);
    }

    [Fact]
    public void RunPart1()
    {
        var input = File.ReadLines("Day2/input.txt");
        var score = Part1(input);
        Assert.Equal(13484, score);
        _testOutputHelper.WriteLine($"Part 1: {score}");
    }

    [Fact]
    public void Example_Part2()
    {
        var input = File.ReadLines("Day2/example.txt");
        var score = Part2(input);
        Assert.Equal(12, score);
    }

    [Fact]
    public void Run_Part2()
    {
        var input = File.ReadLines("Day2/input.txt");
        var score = Part2(input);
        _testOutputHelper.WriteLine($"Part 2: {score}");
        Assert.Equal(13433, score);
    }

    private int Part1(IEnumerable<string> input) => input.Sum(s => Calculate(s.Split(" ")));
    private int Part2(IEnumerable<string> input) => input.Sum(s => CalculatePart2(s.Split(" ")));

    private int CalculatePart2(string[] inputs)
    {
        var player = MapPlayer(inputs[0]);
        
        var input = inputs[1];
        var outcome = OutcomePart2(player, input);
        return outcome + MoveScore(input);
    }

    private int OutcomePart2(string player, string move)
    {
        switch (move)
        {
            case "X":
                return LoseOutcome(player);
            case "Y":
                return Score(player);
            case "Z":
                return WinOutcome(player);
            default:
                throw new NotSupportedException("Input not supported");
        }
    }

    private int WinOutcome(string player)
    {
        return player switch
        {
            Rock => Score(Paper),
            Paper => Score(Scissors),
            Scissors => Score(Rock),
            _ => throw new NotSupportedException("move not supported")
        };
    }

    private int LoseOutcome(string player)
    {
        return player switch
        {
            Rock => Score(Scissors),
            Paper => Score(Rock),
            Scissors => Score(Paper),
            _ => throw new NotSupportedException("move not supported")
        };
    }

    private int Calculate(string[] inputs)
    {
        var player = MapPlayer(inputs[0]);
        var mine = MapPlayer(inputs[1]);

        var outcome = Outcome(player, mine);
        return outcome + Score(mine);
    }

    private int Outcome(string player, string mine)
    {
        if (player == mine)
            return Draw;
        if (player == Rock && mine == Paper) return Win;
        if (player == Rock && mine == Scissors) return Lose;
        if (player == Paper && mine == Rock) return Lose;
        if (player == Paper && mine == Scissors) return Win;
        if (player == Scissors && mine == Rock) return Win;
        if (player == Scissors && mine == Paper) return Lose;

        throw new NotSupportedException("move not supported");
    }

    private int MoveScore(string move) =>
        move switch
        {
            "X" => Lose,
            "Y" => Draw,
            "Z" => Win,
            _ => throw new NotSupportedException("Input not supported")
        };

    private int Score(string move) =>
        move switch
        {
            Rock => 1,
            Paper => 2,
            Scissors => 3,
            _ => throw new NotSupportedException("Input not supported")
        };

    private string MapPlayer(string input) =>
        input switch
        {
            "A" => Rock,
            "X" => Rock,
            "B" => Paper,
            "Y" => Paper,
            "C" => Scissors,
            "Z" => Scissors,
            _ => throw new NotSupportedException("Input not supported")
        };
}