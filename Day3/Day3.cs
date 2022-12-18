using Xunit.Abstractions;

namespace AdventOfCode2022;

public static class Extensions
{
    public static (string first, string last) SplitHalf(this string input)
    {
        var middle = input.Length / 2;
        var first = input[..middle];
        var last = input.Substring(middle, input.Length - middle);
        return (first, last);
    }
}

public class Day3
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day3(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test_Priority()
    {
        Assert.Equal(1, Priority('a'));
        Assert.Equal(26, Priority('z'));
        Assert.Equal(27, Priority('A'));
        Assert.Equal(52, Priority('Z'));
    }

    [Fact]
    public void Example()
    {
        var input = File.ReadLines("Day3/example.txt");
        var result = input.Sum(Calculate);
        Assert.Equal(157, result);
    }

    [Fact]
    public void RunPart1()
    {
        var input = File.ReadLines("Day3/input.txt");
        var result = input.Sum(Calculate);
        _testOutputHelper.WriteLine($"Part 1: {result}");
        Assert.Equal(7817, result);
    }

    [Fact]
    public void Example_Part2()
    {
        var input = File.ReadLines("Day3/example.txt");
        var result = Part2(input);
        Assert.Equal(70, result);
    }

    [Fact]
    public void RunPart2()
    {
        var input = File.ReadLines("Day3/input.txt");
        var result = Part2(input);
        _testOutputHelper.WriteLine($"Part 2: {result}");
        Assert.Equal(2444, result);
    }

    private int Part2(IEnumerable<string> input) =>
        input.Chunk(3).Sum(s =>
            Priority(s.Aggregate((a1, a2) => new string(a1.Intersect(a2).ToArray())).Single()));

    private int Calculate(string s)
    {
        var (first, last) = s.SplitHalf();
        return Priority(first.Intersect(last).Single());
    }

    private int Priority(char input)
    {
        if (char.IsLower(input))
            return input - 96;
        return input - 38;
    }
}