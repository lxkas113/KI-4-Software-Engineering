using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Basisklasse für alle Betriebsmodi des Ofens, implementiert das Vorheizen über zugewiesene Thermalkomponenten.
    /// </summary>
    public class BaseModeStrategy : IModeStrategy
    {
        private readonly List<IThermalController> _thermalControllers;

        /// <summary>
        /// Erstellt eine neue Instanz mit einer Liste von Thermalkomponenten.
        /// </summary>
        /// <param name="thermalControllers">Liste der für den Modus aktiven Komponenten.</param>
        public BaseModeStrategy(List<IThermalController> thermalControllers)
        {
            _thermalControllers = thermalControllers;
        }

        /// <summary>
        /// Führt den Modus aus, indem Heizkomponenten abhängig von der Zieltemperatur aktiviert oder deaktiviert werden.
        /// </summary>
        /// <param name="targetTemperature">Die gewünschte Zieltemperatur.</param>
        /// <returns>Gibt zurück, ob sich der Ofen noch im Vorheizvorgang befindet.</returns>
        public virtual bool Run(int targetTemperature)
        {
            bool stillPreheating = true;

            foreach (var controller in _thermalControllers)
            {
                if (controller is Ventilator)
                {
                    controller.TurnOn();
                    continue;
                }

                if (controller is ITemperatureSource tempSource)
                {
                    int currentTemp = tempSource.Temperature;

                    if (currentTemp < targetTemperature)
                    {
                        controller.TurnOn();
                    }
                    else
                    {
                        controller.TurnOff();
                        stillPreheating = false;
                    }
                }
            }

            return stillPreheating;
        }
    }
}