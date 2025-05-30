namespace OvenProject.InputHandlerModule;

public class TemperatureRotaryController : BaseRotaryController<int>
{
    private const int MinTemperature = 50;
    private const int MaxTemperature = 300;
    
    public override int ReadInput()
    {
        var temperature = GetModuloAngle() * 300 / 270;

        if (temperature < MinTemperature) return 0;
        if (temperature > MaxTemperature) return MaxTemperature;
        return temperature;
    }
}