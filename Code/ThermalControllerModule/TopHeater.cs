namespace OvenProject.ThermalControllerModule;

public class TopHeater : IThermalController, ITemperatureSource
{
    private static TopHeater _instance;
    private bool _active;

    private TopHeater()
    {
        Temperature = 0;
    }

    public static TopHeater GetInstance()
    {
        return _instance ??= new TopHeater();
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