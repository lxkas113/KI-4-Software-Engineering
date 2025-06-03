namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Leerlaufmodus – deaktiviert alle Heizelemente.
    /// </summary>
    public class IdleMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Leerlaufmodus ohne aktive Komponenten.
        /// </summary>
        public IdleMode()
            : base([])
        {
        }
    }
}