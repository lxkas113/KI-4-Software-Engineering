using OvenProject.OvenControllerModule;
using OvenProject.SensorModule;

namespace OvenProject.SafetyModule;

public class DoorOpenRule(ISensor<bool> doorSensor, OvenController oven) : ISafetyRule
{
    public void Check()
    {
        if (doorSensor.GetValue())
        {
            oven.SetState(new IdleState());
        }
    }
}