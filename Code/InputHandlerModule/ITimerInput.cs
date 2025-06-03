namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Definiert die Schnittstelle zur Eingabe eines Timers.
    /// </summary>
    public interface ITimerInput
    {
        /// <summary>
        /// Liest den aktuell eingestellten Zeitwert.
        /// </summary>
        /// <returns>Die verbleibende Zeit als <see cref="TimeSpan"/>.</returns>
        TimeSpan ReadInput();
    }
}