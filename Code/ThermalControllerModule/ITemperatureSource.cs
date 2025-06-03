namespace OvenProject.ThermalControllerModule
{
    /// <summary>
    /// Schnittstelle für Komponenten, die eine Temperatur liefern können.
    /// </summary>
    public interface ITemperatureSource
    {
        /// <summary>
        /// Die aktuell gemessene Temperatur.
        /// </summary>
        int Temperature { get; set; }
    }
}