namespace OvenProject.ThermalControllerModule
{
    /// <summary>
    /// Repräsentiert den Ventilator des Ofens zur Luftzirkulation.
    /// </summary>
    public class Ventilator : IThermalController
    {
        private static Ventilator _instance;
        private bool _active;

        private Ventilator()
        {
            _active = false;
        }

        /// <summary>
        /// Gibt die Singleton-Instanz des Ventilators zurück.
        /// </summary>
        public static Ventilator GetInstance()
        {
            return _instance ??= new Ventilator();
        }

        /// <inheritdoc/>
        public void TurnOn() => _active = true;

        /// <inheritdoc/>
        public void TurnOff() => _active = false;

        /// <inheritdoc/>
        public bool IsActive() => _active;

#if DEBUG
        /// <summary>
        /// Setzt den Status des Ventilators für Tests.
        /// </summary>
        public void SetActive(bool active) => _active = active;
#endif
    }
}