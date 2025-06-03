using OvenProject.ThermalControllerModule;

namespace OvenProject.SensorModule;
public class TemperatureSensor : ISensor<int>
{
    private int _temperature = 0;
    private List<ITemperatureSource> _tempSources = new()
    {
        TopHeater.GetInstance(),
        RearHeater.GetInstance(),
        BottomHeater.GetInstance()
    };

    public int GetValue()
    {
        #if DEBUG
        return _temperature;
        #endif
        
        UpdateTemperature();
        return _temperature;
    }

    public void UpdateTemperature()
    {
        int maxTemp = 0;
        foreach (ITemperatureSource tempSource in _tempSources)
        {
            int currentTemp = tempSource.Temperature;
            if (currentTemp > maxTemp)
            {
                maxTemp = currentTemp;
            }
        }
        _temperature = maxTemp;
    }
    
    #if DEBUG
    public void SetTemperature(int temperature) => _temperature = temperature;
    #endif
}