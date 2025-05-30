namespace OvenProject.ThermalControllerModule;

public interface IThermalController
{
    void TurnOn();
    void TurnOff();
    bool IsActive();
}