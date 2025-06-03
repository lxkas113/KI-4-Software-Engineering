using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Testbetriebsmodus – verwendet alle verfügbaren Heizquellen inklusive Ventilator.
    /// </summary>
    public class DefaultMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Testmodus mit allen Heizkomponenten.
        /// </summary>
        public DefaultMode()
            : base(new List<IThermalController>
            {
                TopHeater.GetInstance(),
                BottomHeater.GetInstance(),
                RearHeater.GetInstance(),
                Ventilator.GetInstance()
            })
        {
        }
    }
}