namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Interpretiert den Winkel eines Drehreglers zur Auswahl der Zieltemperatur.
    /// </summary>
    public class TemperatureRotaryController : BaseRotaryController<int>
    {
        private const int MinTemperature = 50;
        private const int MaxTemperature = 300;

        /// <summary>
        /// Liest die eingestellte Zieltemperatur basierend auf dem aktuellen Winkel.
        /// </summary>
        /// <returns>Die berechnete Temperatur in Grad Celsius.</returns>
        public override int ReadInput()
        {
            var temperature = GetModuloAngle() * 300 / 270;

            if (temperature < MinTemperature) return 0;
            if (temperature > MaxTemperature) return MaxTemperature;

            return temperature;
        }

#if DEBUG
        /// <summary>
        /// Setzt den Winkel für Testzwecke im Debug-Modus.
        /// </summary>
        /// <param name="angle">Der zu setzende Testwinkel.</param>
        public void SetTestAngle(int angle)
        {
            Angle = angle;
        }
#endif
    }
}