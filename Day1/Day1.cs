using MoreLinq.Extensions;
using Xunit.Abstractions;

namespace AdventOfCode2022;

public class Day1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Example()
    {
        var input = File.ReadLines("Day1/example.txt");
        var max = Top(input);
        Assert.Equal(24000, max);
    }
    
    [Fact]
    public void Example_Part2()
    {
        var input = File.ReadLines("Day1/example.txt");
        var sumTop3 = SumTop3(input);
        Assert.Equal(45000, sumTop3);
    }
    
    [Fact]
    public void Part1()
    {
        var input = File.ReadLines("Day1/part1.txt");
        var max = Top(input);
        Assert.Equal(71471, max);
        _testOutputHelper.WriteLine($"Part 1: {max}");
    }
    
    [Fact]
    public void Part2()
    {
        var input = File.ReadLines("Day1/part1.txt");

        var sumTop3 = SumTop3(input);
        Assert.Equal(211189, sumTop3);
        _testOutputHelper.WriteLine($"Part 2: {sumTop3}");
    }

    private static int SumTop3(IEnumerable<string> input) => SumOfGroups(input).Take(3).Sum();
    private static int Top(IEnumerable<string> input) => SumOfGroups(input).First();

    private static IOrderedEnumerable<int> SumOfGroups(IEnumerable<string> input) => input.Split(string.Empty).Select(s => s.Sum(int.Parse)).OrderDescending();
}