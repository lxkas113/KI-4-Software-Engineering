using OvenProject.InputHandlerModule;

namespace OvenProject.Tests.InputHandlerTests;

public class TimerTest
{
    [Fact]
    public void ReadInput_ShouldReturnRemainingTime()
    {
        var timer = new TimerInput();
        var duration = TimeSpan.FromSeconds(5);
        timer.DebugSetTimer(duration);

        Thread.Sleep(1000);
        var remaining = timer.ReadInput();

        Assert.InRange(remaining.TotalMilliseconds, 3800, 4200);
    }

    [Fact]
    public void ReadInput_ShouldBe0_WhenTimerExpired()
    {
        var timer = new TimerInput();
        var duration = TimeSpan.FromMilliseconds(100);
        timer.DebugSetTimer(duration);

        Thread.Sleep(200);
        var remaining = timer.ReadInput();

        Assert.True(remaining.TotalMilliseconds == 0);
    }
}