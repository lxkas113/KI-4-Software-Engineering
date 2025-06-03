namespace OvenProject.ThermalControllerModule
{
    /// <summary>
    /// Repräsentiert das obere Heizelement im Ofen.
    /// </summary>
    public class TopHeater : IThermalController, ITemperatureSource
    {
        private static TopHeater _instance;
        private bool _active;

        private TopHeater()
        {
            Temperature = 0;
        }

        /// <summary>
        /// Gibt die Singleton-Instanz des oberen Heizelements zurück.
        /// </summary>
        public static TopHeater GetInstance()
        {
            return _instance ??= new TopHeater();
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