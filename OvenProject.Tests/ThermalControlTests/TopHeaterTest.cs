using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ThermalControlTests;

public class TopHeaterTest
{
    // TC-5-5
    // Requirements tested: 2.1.7; 2.1.9; 2.1.10
    [Fact]
    public void TurnOn_ShouldSetActiveTrue_AndIncreaseTemperature()
    {
        var heater = TopHeater.GetInstance();
        heater.TurnOff();
        int initialTemp = heater.Temperature;
        
        heater.TurnOn();

        Assert.True(heater.IsActive());
        Assert.Equal(initialTemp + 1, heater.Temperature);
    }

    // TC-5-6
    // Requirements tested: 2.1.7; 2.1.9; 2.1.10
    [Fact]
    public void TurnOff_ShouldSetActiveFalse_AndDecreaseTemperature()
    {
        var heater = TopHeater.GetInstance();
        heater.TurnOn();
        int tempBefore = heater.Temperature;

        heater.TurnOff();
        
        Assert.False(heater.IsActive());
        Assert.Equal(tempBefore - 1, heater.Temperature);
    }
}