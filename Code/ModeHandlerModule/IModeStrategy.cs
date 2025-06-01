using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public interface IModeStrategy
{
    bool Run(int targetTemperature);
}