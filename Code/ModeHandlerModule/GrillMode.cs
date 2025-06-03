using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Grillmodus – verwendet nur das obere Heizelement und reduziert die Temperatur gestuft.
    /// </summary>
    public class GrillMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Grillmodus mit dem oberen Heizelement.
        /// </summary>
        public GrillMode()
            : base(new List<IThermalController>
            {
                TopHeater.GetInstance()
            })
        {
        }

        /// <inheritdoc />
        public override bool Run(int targetTemperature)
        {
            return base.Run(CalculateStepTemperature(targetTemperature));
        }

        /// <summary>
        /// Berechnet eine abgestufte Zieltemperatur je nach Vorgabe.
        /// </summary>
        /// <param name="targetTemperature">Die ursprünglich gewählte Zieltemperatur.</param>
        /// <returns>Die gewählte Stufe.</returns>
        private int CalculateStepTemperature(int targetTemperature)
        {
            if (targetTemperature >= 300) return 300;
            if (targetTemperature >= 280) return 280;
            if (targetTemperature >= 260) return 260;
            if (targetTemperature >= 240) return 240;
            return 0;
        }

#if DEBUG
        /// <summary>
        /// Öffentliche Methode zur Testbarkeit von Temperaturstufung im Debug-Modus.
        /// </summary>
        public int CallCalculateStepTemperature(int targetTemperature)
        {
            return CalculateStepTemperature(targetTemperature);
        }
#endif
    }
}