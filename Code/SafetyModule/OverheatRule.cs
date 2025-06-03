using OvenProject.OvenControllerModule;
using OvenProject.SensorModule;

namespace OvenProject.SafetyModule
{
    /// <summary>
    /// Sicherheitsregel, die bei Überschreiten der Maximaltemperatur einen Fehlerzustand auslöst.
    /// </summary>
    public class OverheatRule(ISensor<int> tempSensor, OvenController oven) : ISafetyRule
    {
        private const int MaxTemp = 320;

        /// <inheritdoc/>
        public void Check()
        {
            if (tempSensor.GetValue() > MaxTemp)
            {
                oven.SetState(new ErrorState());
            }
        }
    }
}