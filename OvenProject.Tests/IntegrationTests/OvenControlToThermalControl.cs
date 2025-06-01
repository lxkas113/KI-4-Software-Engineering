using System.Reflection;
using OvenProject.InputHandlerModule;
using OvenProject.OvenControllerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

public class OvenControlToThermalControl
{   
    [Fact]
    public void OvenController_Run_ActivatesThermalControllers()
    {
        // Arrange
        var oven = new OvenController();

        var top = TopHeater.GetInstance();
        var bottom = BottomHeater.GetInstance();
        var rear = RearHeater.GetInstance();
        var fan = Ventilator.GetInstance();

        // Reset Zustand
        top.TurnOff(); top.Temperature = 100;
        bottom.TurnOff(); bottom.Temperature = 100;
        rear.TurnOff(); rear.Temperature = 100;
        fan.TurnOff();

        // TemperatureRotaryController holen & Testwinkel setzen (~180 °C)
        var tempController = GlobalHelper.GetTemperatureController(oven);
        tempController.SetTestAngle(162); // ergibt ca. 180 °C

        // Act
        oven.Run();

        // Assert
        Assert.True(top.IsActive(), "Top heater should be active");
        Assert.True(bottom.IsActive(), "Bottom heater should be active");
        Assert.True(rear.IsActive(), "Rear heater should be active");
        Assert.True(fan.IsActive(), "Ventilator should be active");
    }
}