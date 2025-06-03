using OvenProject.OvenControllerModule;
using OvenProject.SafetyModule;

namespace OvenProject.Tests.SafetyModuleTest;

public class HeaterFailureRuleTest
{
    // TC-8-3
    // Requirements tested: R-2.3
    [Fact]
    public void Check_ShouldNotTrigger_WhenNotInHeatingState()
    {
        var oven = new OvenController();
        var sensor = oven.GetTempSensor();
        sensor.SetTemperature(150);
        oven.SetState(new IdleState());

        var rule = new HeaterFailureRule(sensor, oven);

        for (int i = 0; i < 10; i++)
        {
            rule.Check();
        }

        Assert.IsNotType<ErrorState>(((StateProxy)oven.GetCurrentState()).GetState());
    }

    // TC-8-4
    // Requirements tested: R-2.3
    [Fact]
     public void Check_ShouldTrigger_WhenTemperatureIsConstantInPreHeating()
     {
         var oven = new OvenController();
         var sensor = oven.GetTempSensor();
         sensor.SetTemperature(150);
         oven.SetState(new PreHeatingState());
 
         var rule = new HeaterFailureRule(sensor, oven);
 
         for (int i = 0; i < 10; i++)
         {
             sensor.SetTemperature(150);
             rule.Check();
         }
 
         Assert.Equal([150, 150, 150, 150, 150, 150, 150, 150, 150, 150], rule.GetLastTemps());
         Assert.IsType<ErrorState>(((StateProxy)oven.GetCurrentState()).GetState());
     }

    // TC-8-5
    // Requirements tested: R-2.3
    [Fact]
    public void Check_ShouldNotTrigger_WhenTemperatureIsChanging()
    {
        var oven = new OvenController();
        var sensor = oven.GetTempSensor();
        sensor.SetTemperature(150);
        oven.SetState(new ActiveState());

        var rule = new HeaterFailureRule(sensor, oven);

        for (int i = 0; i < 10; i++)
        {
            sensor.SetTemperature(100 + i);
            rule.Check();
        }

        Assert.IsNotType<ErrorState>(((StateProxy)oven.GetCurrentState()).GetState());
    }
}