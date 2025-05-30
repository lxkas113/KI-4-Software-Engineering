using OvenProject.GlobalModels;
using OvenProject.OutputHandlerModule;

namespace OvenProject.Tests.DisplayTest;

public class DisplayTest
{
    // Requirements tested: 2.1.12
    [Fact]
    public void Update_ShouldSetAllPropertiesCorrectly()
    {
        var display = new DisplayDummy();
        var output = new OutputValues(
            temperature: 180,
            preheatStatus: true,
            timer: TimeSpan.FromMinutes(45),
            warning: true
        );

        display.Update(output);

        Assert.Equal(180, display.Temperature);
        Assert.True(display.PreheatStatus);
        Assert.Equal(TimeSpan.FromMinutes(45), display.Timer);
        Assert.True(display.Warning);
    }
}