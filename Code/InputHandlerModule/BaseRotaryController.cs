namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Abstrakte Basisklasse für Drehgeber-Controller zur Eingabe von Werten über Rotationswinkel.
    /// </summary>
    /// <typeparam name="T">Der Datentyp des Eingabewerts.</typeparam>
    public abstract class BaseRotaryController<T> : IRotaryController<T>
    {
        /// <summary>
        /// Der aktuelle Winkel des Drehgebers.
        /// </summary>
        public int Angle { get; set; } = 0;

        /// <summary>
        /// Gibt den Winkel im Bereich von 0 bis 359 Grad zurück.
        /// </summary>
        /// <returns>Winkel modulo 360.</returns>
        protected int GetModuloAngle()
        {
            return Angle % 360;
        }

        /// <summary>
        /// Liest den Eingabewert basierend auf dem aktuellen Winkel.
        /// </summary>
        /// <returns>Der interpretierte Eingabewert vom Typ T.</returns>
        public abstract T ReadInput();
    }
}