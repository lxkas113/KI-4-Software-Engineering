using OvenProject.OvenControllerModule;
using OvenProject.SafetyModule;
using OvenProject.SensorModule;

namespace OvenProject.Tests.SafetyModuleTest;

/// <summary>
/// Testet die Sicherheitsregel, die den Ofen bei geöffneter Tür in den Idle-Zustand versetzt.
/// </summary>
public class DoorRuleTest
{
    // TC-8-1
    // Requirements tested: R-2.2
    [Fact]
    public void Check_ShouldSetIdleState_WhenDoorIsOpen()
    {
        var oven = new OvenController();
        var doorSensor = oven.GetDoorSensor();
        doorSensor.SetDoorState(true);
        
        var rule = new DoorOpenRule(doorSensor, oven);

        rule.Check();

        var state = ((StateProxy)oven.GetCurrentState()).GetState();
        Assert.IsType<IdleState>(state);
    }

    // TC-8-2
    // Requirements tested: R-2.2
    [Fact]
    public void Check_ShouldNotChangeState_WhenDoorIsClosed()
    {
        var oven = new OvenController();
        oven.SetState(new ActiveState());
        var doorSensor = oven.GetDoorSensor();
        doorSensor.SetDoorState(false);
        
        var rule = new DoorOpenRule(doorSensor, oven);

        rule.Check();

        var state = ((StateProxy)oven.GetCurrentState()).GetState();
        Assert.IsType<ActiveState>(state);
    }
}