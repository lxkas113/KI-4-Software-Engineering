using OvenProject.OvenControllerModule;
using OvenProject.SensorModule;

namespace OvenProject.SafetyModule;

public class OverheatRule(ISensor<int> tempSensor, OvenController oven) : ISafetyRule
{
    private const int MaxTemp = 320;

    public void Check()
    {
        if (tempSensor.GetValue() > MaxTemp)
        {
            oven.SetState(new ErrorState());
        }
    }
}