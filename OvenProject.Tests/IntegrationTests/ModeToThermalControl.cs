using OvenProject.ModeHandlerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

public class ModeToThermalControl
{
    // TC-0-3
    [Fact]
    public void Run_TurnsOnVentilator()
    {
        var ventilator = Ventilator.GetInstance();
        ventilator.TurnOff();

        var mode = new DefaultMode();

        mode.Run(200);

        Assert.True(ventilator.IsActive());
    }

    // TC-0-4
    // Requirements tested: R-1.9; R-1.10 
    [Theory]
    [InlineData(150, true)]
    [InlineData(210, false)]
    [InlineData(200, false)]
    public void Run_SetsHeaterStateBasedOnTemperature(int temp, bool expectedActive)
    {
        var top = TopHeater.GetInstance();
        var bottom = BottomHeater.GetInstance();
        var rear = RearHeater.GetInstance();

        top.TurnOff(); bottom.TurnOff(); rear.TurnOff();
        top.Temperature = temp;
        bottom.Temperature = temp;
        rear.Temperature = temp;

        var mode = new DefaultMode();
        mode.Run(200);

        Assert.Equal(expectedActive, top.IsActive());
        Assert.Equal(expectedActive, bottom.IsActive());
        Assert.Equal(expectedActive, rear.IsActive());
    }
}