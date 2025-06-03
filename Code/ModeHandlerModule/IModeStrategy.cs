namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Schnittstelle für eine Betriebsmodus-Strategie im Ofen.
    /// </summary>
    public interface IModeStrategy
    {
        /// <summary>
        /// Führt die Strategie zur Steuerung der Heizkomponenten aus.
        /// </summary>
        /// <param name="targetTemperature">Zieltemperatur für die aktuelle Betriebsart.</param>
        /// <returns>True, wenn das Vorheizen noch nicht abgeschlossen ist.</returns>
        bool Run(int targetTemperature);
    }
}