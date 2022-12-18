using Xunit.Abstractions;

namespace AdventOfCode2022;

public class DayN
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DayN(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Example()
    {
        var input = File.ReadLines($"{nameof(DayN)}/example.txt");
        var result = 1;
        Assert.Equal(1, result);
    }
    [Fact]
    public void Part1()
    {
        var input = File.ReadLines($"{nameof(DayN)}/input.txt");
        var result = 1;
        Assert.Equal(1, result);
        _testOutputHelper.WriteLine($"Part 1: {result}");
    }
    
    [Fact]
    public void Example_Part2()
    {
        var input = File.ReadLines($"{nameof(DayN)}/example.txt");
        var result = 0;
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void Part2()
    {
        var input = File.ReadLines($"{nameof(DayN)}/input.txt");

        var result = 0;
        Assert.Equal(0, result);
        _testOutputHelper.WriteLine($"Part 2: {result}");
    }
}