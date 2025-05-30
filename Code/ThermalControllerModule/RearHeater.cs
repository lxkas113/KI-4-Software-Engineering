namespace OvenProject.ThermalControllerModule;

public class RearHeater : IThermalController, ITemperatureSource
{
    private static RearHeater _instance;
    private bool _active;

    private RearHeater() {
        Temperature = 0;
    }

    public static RearHeater GetInstance()
    {
        return _instance ??= new RearHeater();
    }

    public void TurnOn()
    {
        _active = true;
        Temperature += 1;
    }

    public void TurnOff()
    { 
        _active = false;
        Temperature -= 1;
    }

    public bool IsActive() => _active;

    public int Temperature { get; set; }
}