using OvenProject.OvenControllerModule;
using OvenProject.SafetyModule;

namespace OvenProject.Tests.SafetyModuleTest;

/// <summary>
/// Testet die OverheatRule, die bei Überschreiten der maximal zulässigen Temperatur einen Fehlerzustand auslöst.
/// </summary>
public class OverHeatRuleTest
{
    // TC-8-6
    // Requirements tested: R-2.1
    [Fact]
    public void OverheatRule_ShouldTriggerError_WhenTempTooHigh()
    {
        var oven = new OvenController();
        var tempSensor = oven.GetTempSensor();
        tempSensor.SetTemperature(350);
        Assert.Equal(350, tempSensor.GetValue());
        
        var rule = new OverheatRule(tempSensor, oven);
        rule.Check();
        
        Assert.IsType<ErrorState>(((StateProxy)oven.GetCurrentState()).GetState());
    }
}