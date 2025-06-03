namespace OvenProject.ThermalControllerModule
{
    /// <summary>
    /// Repräsentiert das untere Heizelement im Ofen.
    /// </summary>
    public class BottomHeater : IThermalController, ITemperatureSource
    {
        private static BottomHeater _instance;
        private bool _active;

        private BottomHeater() {
            Temperature = 0;
        }

        /// <summary>
        /// Gibt die Singleton-Instanz des unteren Heizelements zurück.
        /// </summary>
        public static BottomHeater GetInstance()
        {
            return _instance ??= new BottomHeater();
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