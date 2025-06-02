using System.Reflection;
using OvenProject.InputHandlerModule;
using OvenProject.ModeHandlerModule;
using OvenProject.OvenControllerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

public class OvenControlToThermalControl
{   
    [Fact]
    public void OvenController_Run_ActivatesThermalControllers()
    {
        var oven = new OvenController();
        oven.SetState(new ActiveState());
        var strategy = new DefaultMode();
        var modeController = new ModeController();
        modeController.SetModeStrategy(strategy);

        var proxy = new ModeControllerProxy();
        proxy.SetModeController(modeController);

        oven.SetModeController(proxy);
        
        var top = TopHeater.GetInstance();
        var bottom = BottomHeater.GetInstance();
        var rear = RearHeater.GetInstance();
        var fan = Ventilator.GetInstance();

        top.TurnOff(); top.Temperature = 100;
        bottom.TurnOff(); bottom.Temperature = 100;
        rear.TurnOff(); rear.Temperature = 100;
        fan.TurnOff();

        var tempController = GlobalHelper.GetTemperatureController(oven);
        tempController.SetTestAngle(162);

        oven.Run();
        
        Assert.True(top.IsActive(), "Top heater should be active");
        Assert.True(bottom.IsActive(), "Bottom heater should be active");
        Assert.True(rear.IsActive(), "Rear heater should be active");
        Assert.True(fan.IsActive(), "Ventilator should be active");
    }
}