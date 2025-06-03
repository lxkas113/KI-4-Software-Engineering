using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Betriebsmodus mit Ober- und Unterhitze.
    /// </summary>
    public class TopBottomHeatMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Modus mit oberen und unteren Heizelementen.
        /// </summary>
        public TopBottomHeatMode()
            : base(new List<IThermalController>
            {
                TopHeater.GetInstance(),
                BottomHeater.GetInstance()
            })
        {
        }
    }
}