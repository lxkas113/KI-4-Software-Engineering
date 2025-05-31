using OvenProject.OvenControllerModule;
using Xunit.Abstractions;

namespace OvenProject.Tests;

public class CycleTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CycleTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    // TC-0-1
    // Requirements tested: 2.1.8
    [Fact]
    public void Run_ShouldCompleteInUnderOneSecond()
    {
        var controller = new OvenController();

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        controller.Run();
        stopwatch.Stop();

        Assert.True(stopwatch.ElapsedMilliseconds < 1000, $"Run dauerte {stopwatch.ElapsedMilliseconds} ms");
    }
    
    // TC-0-2
    // Requirements tested: 2.3.1
    [Fact]
    public void ShouldReach200CelsiusWithin10Minutes()
    {
        var controller = new OvenController();
        int temperature = 0;
        
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        while (temperature < 200 && stopwatch.Elapsed.TotalMinutes < 10)
        {
            controller.Run();
            temperature++;
        }

        stopwatch.Stop();

        Assert.True(temperature >= 200, "Temperatur wurde nicht erreicht.");
        Assert.True(stopwatch.Elapsed.TotalMinutes <= 10, $"Zeitlimit überschritten: {stopwatch.Elapsed.TotalMinutes} Minuten");
    }
}