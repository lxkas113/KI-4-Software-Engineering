using OvenProject.ModeHandlerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ModeControllerTests;

/// <summary>
/// Testet den Idle Mode.
/// </summary>
public class IdleModeTest
{
    // TC-4-6
    // Requirements tested: R-1.6 
    [Fact]
    public void BottomHeatMode_ShouldIncreaseBottomHeaterTemperatureByOne()
    {
        var topHeater = TopHeater.GetInstance();
        var bottomHeater = BottomHeater.GetInstance();
        var rearHeater = RearHeater.GetInstance();
        var ventilator = Ventilator.GetInstance();

        topHeater.Temperature = 50;
        bottomHeater.Temperature = 50;
        rearHeater.Temperature = 50;
        ventilator.SetActive(false);

        var mode = new IdleMode();

        mode.Run(100);

        Assert.Equal(50, topHeater.Temperature);
        Assert.Equal(50, bottomHeater.Temperature);
        Assert.Equal(50, rearHeater.Temperature);
        Assert.False(ventilator.IsActive());
    }
}