namespace OvenProject.GlobalModels
{
    /// <summary>
    /// Repräsentiert die vom Ofen zurückgemeldeten Ausgabewerte während oder nach dem Betrieb.
    /// </summary>
    public class OutputValues
    {
        /// <summary>
        /// Die aktuelle Temperatur des Ofens (in Grad Celsius).
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Gibt an, ob die Vorheizphase abgeschlossen ist.
        /// </summary>
        public bool PreheatStatus { get; set; }

        /// <summary>
        /// Die verbleibende Zeit des laufenden Timers.
        /// </summary>
        public TimeSpan Timer { get; set; }

        /// <summary>
        /// Gibt an, ob ein Warnzustand erkannt wurde (z.B. Überhitzung).
        /// </summary>
        public bool Warning { get; set; }

        /// <summary>
        /// Erstellt eine neue Instanz von <see cref="OutputValues"/> mit den übergebenen Werten.
        /// </summary>
        /// <param name="temperature">Die aktuelle Temperatur.</param>
        /// <param name="preheatStatus">Status des Vorheizens.</param>
        /// <param name="timer">Verbleibende Zeit.</param>
        /// <param name="warning">Warnstatus.</param>
        public OutputValues(int temperature, bool preheatStatus, TimeSpan timer, bool warning)
        {
            Temperature = temperature;
            PreheatStatus = preheatStatus;
            Timer = timer;
            Warning = warning;
        }
    }
}