using OvenProject.ModeHandlerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ModeControllerTests;

/// <summary>
/// Testet den CirculatingAirMode hinsichtlich Aktivierung von Ober- und Unterhitze sowie Ventilatorfunktion.
/// </summary>

public class CirculatingAirModeTest
{
    // TC-4-2
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

        var mode = new CirculatingAirMode();

        mode.Run(100);

        Assert.Equal(51, topHeater.Temperature);
        Assert.Equal(51, bottomHeater.Temperature);
        Assert.Equal(50, rearHeater.Temperature);
        Assert.True(ventilator.IsActive());
    }
}