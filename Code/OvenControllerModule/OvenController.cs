using OvenProject.GlobalModels;
using OvenProject.InputHandlerModule;
using OvenProject.SensorModule;
using OvenProject.ModeHandlerModule;
using OvenProject.OutputHandlerModule;

namespace OvenProject.OvenControllerModule;

public class OvenController
{
    private IState _currentState;
    private TemperatureSensor _tempSensor;
    private ModeController _modeController;
    private InputHandler _inputHandler;
    private DisplayDummy _display;

    public OvenController()
    {
        _inputHandler = new InputHandler();
        _modeController = new ModeController();
        _currentState = new ActiveState();
        _tempSensor = new TemperatureSensor();
        _display = new DisplayDummy();
    }

    public void SetState(IState newState)
    {
        _currentState = newState;
    }

    public void Run()
    {
        _currentState.Run(this);
    }

    public virtual InputValues GetInput()
    {
        return _inputHandler.ReadInputs();
    }

    public virtual ModeController GetModeController()
    {
        return _modeController;
    }
    
    public virtual int GetTemperature()
    {
        return _tempSensor.GetValue();
    }

    public virtual DisplayDummy GetDisplay()
    {
        return _display;
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