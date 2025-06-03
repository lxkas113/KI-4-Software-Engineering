using OvenProject.ModeHandlerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.ModeControllerTests;

/// <summary>
/// Überprüft die Funktion des GrillMode inkl. Temperaturstufung und Aktivierung des oberen Heizelements.
/// </summary>
public class GrillModeTest
{
    // TC-4-3
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

        var mode = new GrillMode();

        mode.Run(240);

        Assert.Equal(51, topHeater.Temperature);
        Assert.Equal(50, bottomHeater.Temperature);
        Assert.Equal(50, rearHeater.Temperature);
        Assert.False(ventilator.IsActive());
    }
    
    // TC-4-4
    // Requirements tested: R-1.11
    [Theory]
    [InlineData(100, 0)]
    [InlineData(239, 0)]
    [InlineData(240, 240)]
    [InlineData(259, 240)]
    [InlineData(260, 260)]
    [InlineData(279, 260)]
    [InlineData(280, 280)]
    [InlineData(299, 280)]
    [InlineData(300, 300)]
    [InlineData(320, 300)]
    public void CalculateStepTemperature_ShouldMapToCorrectStep(int input, int expected)
    {
        var mode = new GrillMode();
        int result = mode.CallCalculateStepTemperature(input);
        Assert.Equal(expected, result);
        
    }
}