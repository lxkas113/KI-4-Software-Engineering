using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class DefaultMode : IModeStrategy
{
    private readonly List<IThermalController> _thermalControllers;

    public DefaultMode()
    {
        _thermalControllers = new List<IThermalController>
        {
            TopHeater.GetInstance(),
            BottomHeater.GetInstance(),
            RearHeater.GetInstance(),
            Ventilator.GetInstance()
        };
    }
    
    public void Run(int targetTemperature)
    {
        foreach (var controller in _thermalControllers)
        {
            // Ventilator immer einschalten
            if (controller is Ventilator)
            {
                controller.TurnOn();
                continue;
            }

            // Alle anderen prüfen, ob sie Temperaturquelle sind
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
                }
            }
        }
    }
}