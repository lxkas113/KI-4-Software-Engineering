using OvenProject.ModeHandlerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ModeControllerTests;

public class HotAirModeTest
{
    // TC-4-5
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

        var mode = new HotAirMode();

        mode.Run(100);

        Assert.Equal(50, topHeater.Temperature);
        Assert.Equal(50, bottomHeater.Temperature);
        Assert.Equal(51, rearHeater.Temperature);
        Assert.True(ventilator.IsActive());
    }
}