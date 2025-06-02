using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class BaseModeStrategy : IModeStrategy
{
    private readonly List<IThermalController> _thermalControllers;

    public BaseModeStrategy(List<IThermalController> thermalControllers)
    {
        _thermalControllers = thermalControllers;
    }
    
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