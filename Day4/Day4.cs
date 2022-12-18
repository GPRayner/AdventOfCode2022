using Xunit.Abstractions;

namespace AdventOfCode2022;

public class Day4
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day4(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private (int firstStart, int firstEnd, int secondStart, int secondEnd) Parse(string input)
    {
        var list = input.Split(",").SelectMany(sm => sm.Split("-").Select(int.Parse)).ToArray();
        return (list[0], list[1], list[2], list[3]);
    }

    [Fact]
    public void Example()
    {
        var input = File.ReadLines($"{nameof(Day4)}/example.txt");
        var result = Part1(input);
        Assert.Equal(2, result);
    }

    private int Part1(IEnumerable<string> input) => input.Select(Parse).Count(CompletelyOverlaps);

    private bool CompletelyOverlaps((int firstStart, int firstEnd, int secondStart, int secondEnd) arg)
        => (arg.firstStart >= arg.secondStart && arg.firstEnd <= arg.secondEnd) ||
           (arg.secondStart >= arg.firstStart && arg.secondEnd <= arg.firstEnd);

    [Fact]
    public void Run_Part1()
    {
        var input = File.ReadLines($"{nameof(Day4)}/input.txt");
        var result = Part1(input);
        Assert.Equal(534, result);
        _testOutputHelper.WriteLine($"Part 1: {result}");
    }

    [Fact]
    public void Example_Part2()
    {
        var input = File.ReadLines($"{nameof(Day4)}/example.txt");
        var result = Part2(input);
        Assert.Equal(4, result);
    }

    private int Part2(IEnumerable<string> input) => input.Select(Parse).Count(Overlaps);

    private bool Overlaps((int firstStart, int firstEnd, int secondStart, int secondEnd) arg)
        => Math.Max(arg.firstEnd, arg.secondEnd) - Math.Min(arg.firstStart, arg.secondStart) <=
           (arg.firstEnd - arg.firstStart) + (arg.secondEnd - arg.secondStart);

    [Fact]
    public void Run_Part2()
    {
        var input = File.ReadLines($"{nameof(Day4)}/input.txt");
        var result = Part2(input);
        Assert.Equal(841, result);
        _testOutputHelper.WriteLine($"Part 2: {result}");
    }
}