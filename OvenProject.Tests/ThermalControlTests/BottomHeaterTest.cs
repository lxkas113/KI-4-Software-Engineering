using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ThermalControlTests;

/// <summary>
/// Testet die Funktionalität des BottomHeater.
/// </summary>
public class BottomHeaterTest
{
    // TC-5-1
    // Requirements tested: R-1.7; R-1.9; R-1.10
    [Fact]
    public void TurnOn_ShouldSetActiveTrue_AndIncreaseTemperature()
    {
        var heater = BottomHeater.GetInstance();
        heater.TurnOff();
        int initialTemp = heater.Temperature;

        heater.TurnOn();

        Assert.True(heater.IsActive());
        Assert.Equal(initialTemp + 1, heater.Temperature);
    }
    
    // TC-5-2
    // Requirements tested: R-1.7; R-1.9; R-1.10
    [Fact]
    public void TurnOff_ShouldSetActiveFalse_AndDecreaseTemperature()
    {
        var heater = BottomHeater.GetInstance();
        heater.TurnOn();
        int tempBefore = heater.Temperature;

        heater.TurnOff();

        Assert.False(heater.IsActive());
        Assert.Equal(tempBefore - 1, heater.Temperature);
    }
}