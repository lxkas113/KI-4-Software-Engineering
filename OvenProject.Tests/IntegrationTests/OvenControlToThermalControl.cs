using System.Reflection;
using OvenProject.OvenControllerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

public class OvenControlToThermalControl
{
    [Fact]
    public void OvenController_Run_ActivatesThermalControllers()
    {
        var oven = new OvenController();

        var top = TopHeater.GetInstance();
        var bottom = BottomHeater.GetInstance();
        var rear = RearHeater.GetInstance();
        var fan = Ventilator.GetInstance();

        top.TurnOff(); top.Temperature = 100;
        bottom.TurnOff(); bottom.Temperature = 100;
        rear.TurnOff(); rear.Temperature = 100;
        fan.TurnOff();

        var inputHandlerField = typeof(OvenController)
            .GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var inputHandler = inputHandlerField.GetValue(oven)!;

        var tempControllerField = inputHandler.GetType()
            .GetField("_tempController", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var tempController = (dynamic)tempControllerField.GetValue(inputHandler)!;
        tempController.Angle = 180; // ≈ 200°C

        oven.Run();

        Assert.True(top.IsActive(), "Top heater should be active");
        Assert.True(bottom.IsActive(), "Bottom heater should be active");
        Assert.True(rear.IsActive(), "Rear heater should be active");
        Assert.True(fan.IsActive(), "Ventilator should be active");
    }
}