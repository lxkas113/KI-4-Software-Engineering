namespace OvenProject.ThermalControllerModule;

public class Ventilator : IThermalController
{
    private static Ventilator _instance;
    private bool _active;

    private Ventilator()
    {
        _active = false;
    }

    public static Ventilator GetInstance()
    {
        return _instance ??= new Ventilator();
    }

    public void TurnOn() => _active = true;

    public void TurnOff() => _active = false;

    public bool IsActive() => _active;
}