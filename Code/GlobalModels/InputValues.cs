namespace OvenProject.GlobalModels
{
    /// <summary>
    /// Repräsentiert die vom Benutzer eingestellten Eingabewerte für den Ofenbetrieb.
    /// </summary>
    public class InputValues
    {
        /// <summary>
        /// Die Zieltemperatur, die der Ofen erreichen soll (in Grad Celsius).
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Der gewählte Kochmodus, z.B. Umluft oder Ober-/Unterhitze.
        /// </summary>
        public CookingMode Mode { get; set; }

        /// <summary>
        /// Die eingestellte Timerdauer für den Betrieb.
        /// </summary>
        public TimeSpan Timer { get; set; }
    }
}