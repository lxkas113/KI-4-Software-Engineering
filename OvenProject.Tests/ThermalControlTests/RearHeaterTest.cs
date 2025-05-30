using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ThermalControlTests;

public class RearHeaterTest
{
    // Requirements tested: 2.1.7; 2.2.1
    [Fact]
    public void TurnOn_ShouldSetActiveTrue_AndIncreaseTemperature()
    {
        var heater = RearHeater.GetInstance();
        heater.TurnOff();
        int initialTemp = heater.Temperature;

        heater.TurnOn();

        Assert.True(heater.IsActive());
        Assert.Equal(initialTemp + 1, heater.Temperature);
    }

    // Requirements tested: 2.1.7; 2.2.1
    [Fact]
    public void TurnOff_ShouldSetActiveFalse_AndDecreaseTemperature()
    {
        var heater = RearHeater.GetInstance();
        heater.TurnOn();
        int tempBefore = heater.Temperature;

        heater.TurnOff();

        Assert.False(heater.IsActive());
        Assert.Equal(tempBefore - 1, heater.Temperature);
    }
}