using OvenProject.OvenControllerModule;
using OvenProject.SensorModule;

namespace OvenProject.SafetyModule
{
    /// <summary>
    /// Sicherheitsregel, die den Ofen in den Leerlauf versetzt, wenn die Tür geöffnet ist.
    /// </summary>
    public class DoorOpenRule(ISensor<bool> doorSensor, OvenController oven) : ISafetyRule
    {
        /// <inheritdoc/>
        public void Check()
        {
            if (doorSensor.GetValue())
            {
                oven.SetState(new IdleState());
            }
        }
    }
}