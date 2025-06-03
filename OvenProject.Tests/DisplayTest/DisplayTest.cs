using OvenProject.GlobalModels;
using OvenProject.OutputHandlerModule;

namespace OvenProject.Tests.DisplayTest;

/// <summary>
/// Prüft die Darstellung und Aktualisierung der Ausgabewerte im Display.
/// </summary>
public class DisplayTest
{
    // TC-6-1
    // Requirements tested: R-1.12
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