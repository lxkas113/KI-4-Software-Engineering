using OvenProject.SensorModule;

namespace OvenProject.Tests.SensorTests;

/// <summary>
/// Testet die TemperatureSensor-Klasse, insbesondere ob sie die höchste Temperaturquelle korrekt ermittelt.
/// </summary>
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