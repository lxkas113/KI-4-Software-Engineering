using OvenProject.OvenControllerModule;
using OvenProject.SensorModule;

namespace OvenProject.SafetyModule;

public class HeaterFailureRule : ISafetyRule
{
    private readonly TemperatureSensor _tempSensor;
    private readonly OvenController _oven;
    private readonly int[] _lastTemps = new int[10];
    private int _index = 0;
    private int _count = 0;

    public HeaterFailureRule(TemperatureSensor tempSensor, OvenController oven)
    {
        _tempSensor = tempSensor;
        _oven = oven;
    }

    public void Check()
    {
        var state = ((StateProxy)_oven.GetCurrentState()).GetState();

        if (state is not PreHeatingState && state is not ActiveState)
        {
            return;
        }

        _lastTemps[_index] = _tempSensor.GetValue();
        _index = (_index + 1) % _lastTemps.Length;
        if (_count < _lastTemps.Length) _count++;

        if (_count == _lastTemps.Length && _lastTemps.All(t => t == _lastTemps[0]))
        {
            _oven.SetState(new ErrorState());
        }
    }
    
    #if DEBUG
    public int[] GetLastTemps() => _lastTemps;
    #endif
    
    #if DEBUG
    public int GetIndex() => _index;
    #endif
}