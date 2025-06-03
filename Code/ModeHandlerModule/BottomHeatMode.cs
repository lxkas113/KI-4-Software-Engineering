using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Betriebsmodus für Unterhitze, verwendet ausschließlich das untere Heizelement.
    /// </summary>
    public class BottomHeatMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Modus mit dem unteren Heizelement.
        /// </summary>
        public BottomHeatMode()
            : base(new List<IThermalController>
            {
                BottomHeater.GetInstance()
            })
        {
        }
    }
}