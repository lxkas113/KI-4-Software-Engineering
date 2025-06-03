namespace OvenProject.ThermalControllerModule
{
    /// <summary>
    /// Repräsentiert das hintere Heizelement im Ofen.
    /// </summary>
    public class RearHeater : IThermalController, ITemperatureSource
    {
        private static RearHeater _instance;
        private bool _active;

        private RearHeater() {
            Temperature = 0;
        }

        /// <summary>
        /// Gibt die Singleton-Instanz des hinteren Heizelements zurück.
        /// </summary>
        public static RearHeater GetInstance()
        {
            return _instance ??= new RearHeater();
        }

        /// <inheritdoc/>
        public void TurnOn()
        {
            _active = true;
            Temperature += 1;
        }

        /// <inheritdoc/>
        public void TurnOff()
        {
            _active = false;
            Temperature -= 1;
        }

        /// <inheritdoc/>
        public bool IsActive() => _active;

        /// <inheritdoc/>
        public int Temperature { get; set; }
    }
}