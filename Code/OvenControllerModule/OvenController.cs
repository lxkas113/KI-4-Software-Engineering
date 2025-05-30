using OvenProject.GlobalModels;
using OvenProject.SensorModule;
using OvenProject.ModeHandlerModule;

namespace OvenProject.OvenControllerModule;

public class OvenController
{
    private IState _currentState;
    private TemperatureSensor _tempSensor;
    private ModeController _modeController;

    public OvenController()
    {
        _modeController = new ModeController();
        _currentState = new ActiveState();
        _tempSensor = new TemperatureSensor();
    }

    public void SetState(IState newState)
    {
        _currentState = newState;
    }

    public void Run()
    {
        _currentState.Run(this);
    }

    public InputValues GetInput()
    {
        return new InputValues { Temperature = 200 };
    }

    public ModeController GetModeController()
    {
        return _modeController;
    }

    public void Loop()
    {
        for (int i = 0; i < 210; i++)
        {
            Run();
            _tempSensor.UpdateTemperature();
        }
        
    }
}