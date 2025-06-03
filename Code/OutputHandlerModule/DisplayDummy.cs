using OvenProject.GlobalModels;

namespace OvenProject.OutputHandlerModule
{
    /// <summary>
    /// Simuliert ein Anzeigefeld zur Darstellung von Ofen-Ausgabewerten.
    /// </summary>
    public class DisplayDummy
    {
        /// <summary>
        /// Die aktuelle Temperatur, die auf dem Display angezeigt wird.
        /// </summary>
        public int Temperature { get; private set; }

        /// <summary>
        /// Gibt an, ob das Vorheizen abgeschlossen ist.
        /// </summary>
        public bool PreheatStatus { get; private set; }

        /// <summary>
        /// Die auf dem Display angezeigte Zeit (z. B. verbleibende Garzeit).
        /// </summary>
        public TimeSpan Timer { get; private set; }

        /// <summary>
        /// Gibt an, ob eine Warnung angezeigt wird (z. B. Überhitzung).
        /// </summary>
        public bool Warning { get; private set; }

        /// <summary>
        /// Aktualisiert die Display-Daten basierend auf den aktuellen Ausgabewerten des Ofens.
        /// </summary>
        /// <param name="outputValues">Die vom Ofensystem bereitgestellten Ausgabewerte.</param>
        public void Update(OutputValues outputValues)
        {
            Temperature = outputValues.Temperature;
            PreheatStatus = outputValues.PreheatStatus;
            Timer = outputValues.Timer;
            Warning = outputValues.Warning;
        }
    }
}