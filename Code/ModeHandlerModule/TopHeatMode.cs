using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Betriebsmodus mit reiner Oberhitze.
    /// </summary>
    public class TopHeatMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Modus mit dem oberen Heizelement.
        /// </summary>
        public TopHeatMode()
            : base(new List<IThermalController>
            {
                TopHeater.GetInstance()
            })
        {
        }
    }
}