using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Betriebsmodus für Umluftbetrieb – nutzt obere, untere Heizelemente und Ventilator.
    /// </summary>
    public class CirculatingAirMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Umluftmodus mit Heizkörpern und Ventilator.
        /// </summary>
        public CirculatingAirMode()
            : base(new List<IThermalController>
            {
                TopHeater.GetInstance(),
                BottomHeater.GetInstance(),
                Ventilator.GetInstance()
            })
        {
        }
    }
}