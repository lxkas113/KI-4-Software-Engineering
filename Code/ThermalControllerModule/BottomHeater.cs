namespace OvenProject.ThermalControllerModule;

public class BottomHeater : IThermalController, ITemperatureSource
{
    private static BottomHeater _instance;
    private bool _active;

    private BottomHeater() {
        Temperature = 0;
    }

    public static BottomHeater GetInstance()
    {
        return _instance ??= new BottomHeater();
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
