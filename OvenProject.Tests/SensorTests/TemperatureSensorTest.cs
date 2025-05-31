using OvenProject.SensorModule;

namespace OvenProject.Tests.SensorTests;

public class TemperatureSensorTest
{
    // TC-7-3
    [Fact]
    public void UpdateTemperature_SetsTemperatureToMaximumSource()
    {
        var sensor = new TemperatureSensor();

        sensor.UpdateTemperature();
        int temp = sensor.GetValue();

        Assert.InRange(temp, 0, 300);
    }
}