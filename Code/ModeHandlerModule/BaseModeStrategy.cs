using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

/// <summary>
/// Basisklasse für alle Betriebsmodi des Ofens, implementiert das Heizen über zugewiesene Thermalkomponenten.
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

    /// <inheritdoc />
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