using System.Reflection;
using OvenProject.InputHandlerModule;
using OvenProject.ModeHandlerModule;
using OvenProject.OvenControllerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

/// <summary>
/// Integrationstest: von Ofencontroller zu den Heizkomponenten.
/// </summary>
public class OvenControlToThermalControl
{   
    // TC-0-7
    [Fact]
    public void OvenController_Run_ActivatesThermalControllers_CirculatingAir()
    {
        var oven = new OvenController();
        oven.GetTempSensor().ModulTest = false;
        oven.SetState(new ActiveState());
        oven.GetInputHandler().GetInputHandler().GetModeController().Angle = 250;
        oven.GetInputHandler().GetInputHandler().GetTempController().SetTestAngle(180);

        var top = TopHeater.GetInstance();
        var bottom = BottomHeater.GetInstance();
        var fan = Ventilator.GetInstance();

        top.TurnOff(); top.Temperature = 100;
        bottom.TurnOff(); bottom.Temperature = 100;
        fan.TurnOff();
        
        oven.Run();
        
        Assert.True(top.IsActive(), "Top heater should be active");
        Assert.True(bottom.IsActive(), "Bottom heater should be active");
        Assert.True(fan.IsActive(), "Ventilator should be active");
    }
    
    // TC-0-8
    [Fact]
    public void OvenController_Run_ActivatesThermalControllers_HotAir()
    {
        var oven = new OvenController();
        oven.GetTempSensor().ModulTest = false;
        oven.SetState(new ActiveState());
        oven.GetInputHandler().GetInputHandler().GetModeController().Angle = 300;
        oven.GetInputHandler().GetInputHandler().GetTempController().SetTestAngle(180);

        var rear = RearHeater.GetInstance();
        var fan = Ventilator.GetInstance();

        rear.TurnOff(); rear.Temperature = 100;
        fan.TurnOff();
        
        oven.Run();
        
        Assert.True(rear.IsActive(), "Rear heater should be active");
        Assert.True(fan.IsActive(), "Ventilator should be active");
    }
}