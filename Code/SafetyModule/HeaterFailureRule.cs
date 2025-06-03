using OvenProject.OvenControllerModule;
using OvenProject.SensorModule;

namespace OvenProject.SafetyModule
{
    /// <summary>
    /// Sicherheitsregel, die erkennt, ob das Heizelement keine Temperaturveränderung bewirkt.
    /// </summary>
    public class HeaterFailureRule : ISafetyRule
    {
        private readonly TemperatureSensor _tempSensor;
        private readonly OvenController _oven;
        private readonly int[] _lastTemps = new int[10];
        private int _index = 0;
        private int _count = 0;

        /// <summary>
        /// Initialisiert die Regel mit Temperatursensor und Ofeninstanz.
        /// </summary>
        public HeaterFailureRule(TemperatureSensor tempSensor, OvenController oven)
        {
            _tempSensor = tempSensor;
            _oven = oven;
        }

        /// <summary>
        /// Checkt ob die Heizaggregate keine Temperaturveränderung bewirken.
        /// </summary>
        public void Check()
        {
            var state = ((StateProxy)_oven.GetCurrentState()).GetState();

            if (state is not PreHeatingState && state is not ActiveState)
                return;

            _lastTemps[_index] = _tempSensor.GetValue();
            _index = (_index + 1) % _lastTemps.Length;
            if (_count < _lastTemps.Length) _count++;

            if (_count == _lastTemps.Length && _lastTemps.All(t => t == _lastTemps[0]))
            {
                _oven.SetState(new ErrorState());
            }
        }

#if DEBUG
        /// <summary>
        /// Gibt die letzten 10 gemessenen Temperaturen zurück.
        /// </summary>
        public int[] GetLastTemps() => _lastTemps;
        /// <summary>
        /// Gibt den aktuellen Index für die Temperaturmessung zurück.
        /// </summary>
        public int GetIndex() => _index;
#endif
    }
}