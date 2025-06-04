using System.Reflection;
using OvenProject.GlobalModels;
using OvenProject.ModeHandlerModule;
using OvenProject.OvenControllerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.Tests.IntegrationTests;

/// <summary>
/// Testet, ob der Ofencontroller den Displayzustand korrekt aktualisiert.
/// </summary>
public class OvenControllerToDisplay
{
    // TC-0-5
    [Fact]
    public void OvenController_Run_UpdatesDisplayCorrectly()
    {
        var oven = new OvenController();
        oven.GetTempSensor().ModulTest = false;
        oven.SetState(new ActiveState());
        oven.GetInputHandler().GetInputHandler().GetModeController().Angle = 50;
        oven.GetInputHandler().GetInputHandler().GetTempController().SetTestAngle(180);

        TopHeater.GetInstance().Temperature = 180;
        RearHeater.GetInstance().Temperature = 180;
        BottomHeater.GetInstance().Temperature = 180;
        
        oven.Run();

        var display = oven.GetDisplay().GetDisplayDummy();
        Assert.Equal(181, display.Temperature);
        Assert.False(display.PreheatStatus);
        Assert.Equal(TimeSpan.Zero, display.Timer);
        Assert.False(display.Warning);
    }
}