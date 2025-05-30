using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ThermalControlTests;

public class VentilatorTest
{
    // Requirements tested: 2.1.10
    [Fact]
    public void TurnOn_ShouldActivateVentilator()
    {
        var fan = Ventilator.GetInstance();
        fan.TurnOff();

        fan.TurnOn();

        Assert.True(fan.IsActive());
    }

    [Fact]
    public void TurnOff_ShouldDeactivateVentilator()
    {
        var fan = Ventilator.GetInstance();
        fan.TurnOn();

        fan.TurnOff();

        Assert.False(fan.IsActive());
    }
}