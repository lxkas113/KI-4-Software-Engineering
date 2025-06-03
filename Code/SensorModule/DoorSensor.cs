namespace OvenProject.SensorModule;
public class DoorSensor(bool open = false) : ISensor<bool>
{
    private bool _isDoorOpen = open;

    public bool GetValue()
    {
        return _isDoorOpen;
    }

    public void SetDoorState(bool open)
    {
        _isDoorOpen = open;
    }
    
    #if DEBUG
    public void SetDoorValue(bool open) => _isDoorOpen = open;
    #endif
}