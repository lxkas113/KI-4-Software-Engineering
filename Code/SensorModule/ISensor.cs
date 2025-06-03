namespace OvenProject.SensorModule
{
    /// <summary>
    /// Generische Schnittstelle für Sensoren, die einen Wert vom Typ <typeparamref name="T"/> liefern.
    /// </summary>
    /// <typeparam name="T">Datentyp des gemessenen Werts (z. B. bool, int).</typeparam>
    public interface ISensor<T>
    {
        /// <summary>
        /// Gibt den aktuellen Messwert des Sensors zurück.
        /// </summary>
        /// <returns>Der aktuelle Wert des Sensors.</returns>
        T GetValue();
    }
}