using System.Reflection;
using OvenProject.OvenControllerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

public class OvenControllerToDisplay
{
    [Fact]
    public void OvenController_Run_UpdatesDisplayCorrectly()
    {
        var oven = new OvenController();

        TopHeater.GetInstance().Temperature = 180;
        RearHeater.GetInstance().Temperature = 160;
        BottomHeater.GetInstance().Temperature = 150;

        var tempSensorField = typeof(OvenController)
            .GetField("_tempSensor", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var tempSensor = tempSensorField.GetValue(oven)!;
        var updateMethod = tempSensor.GetType().GetMethod("UpdateTemperature")!;
        updateMethod.Invoke(tempSensor, null);

        oven.Run();

        var display = oven.GetDisplay();
        Assert.Equal(180, display.Temperature);
        Assert.False(display.PreheatStatus);
        Assert.Equal(TimeSpan.Zero, display.Timer);
        Assert.False(display.Warning);
    }
}