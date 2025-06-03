using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ThermalControlTests;

/// <summary>
/// Testet die Funktionalität des Ventiators.
/// </summary>
public class VentilatorTest
{
    // TC-5-7
    [Fact]
    public void TurnOn_ShouldActivateVentilator()
    {
        var fan = Ventilator.GetInstance();
        fan.TurnOff();

        fan.TurnOn();

        Assert.True(fan.IsActive());
    }

    // TC-5-8
    [Fact]
    public void TurnOff_ShouldDeactivateVentilator()
    {
        var fan = Ventilator.GetInstance();
        fan.TurnOn();

        fan.TurnOff();

        Assert.False(fan.IsActive());
    }
}