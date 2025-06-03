namespace OvenProject.ThermalControllerModule
{
    /// <summary>
    /// Schnittstelle für thermische Komponenten, die ein- oder ausgeschaltet werden können.
    /// </summary>
    public interface IThermalController
    {
        /// <summary>
        /// Schaltet das thermische Element ein.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Schaltet das thermische Element aus.
        /// </summary>
        void TurnOff();

        /// <summary>
        /// Gibt an, ob das Element momentan aktiv ist.
        /// </summary>
        /// <returns>True, wenn aktiv.</returns>
        bool IsActive();
    }
}