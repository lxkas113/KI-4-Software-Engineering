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
    private ModeControllerProxy _modeController;
    private InputHandlerProxy _inputHandler;
    private DisplayDummyProxy _display;

    public OvenController()
    {
        _inputHandler = new InputHandlerProxy();
        _modeController = new ModeControllerProxy();
        _currentState = new ActiveState();
        _tempSensor = new TemperatureSensor();
        _display = new DisplayDummyProxy();
    }

    public void SetState(IState newState)
    {
        _currentState = newState;
    }

    public void Run()
    {
        _currentState.Run(this, _inputHandler.ReadInputs());
    }

    public virtual ModeControllerProxy GetModeController()
    {
        return _modeController;
    }
    
    public virtual int GetTemperature()
    {
        return _tempSensor.GetValue();
    }

    public virtual DisplayDummyProxy GetDisplay()
    {
        return _display;
    }
    
    public void Loop()
    {
        for (int i = 0; i < 210; i++)
        {
            Run();
        }
        
    }
    
    #if DEBUG
    public IState GetCurrentState() => _currentState;
    #endif
    
    #if DEBUG
    public InputValues GetInput() => _inputHandler.ReadInputs();
    #endif
    
    #if DEBUG
    public void SetModeController(ModeControllerProxy modeController) => _modeController = modeController;
    #endif
    
#if DEBUG
    public void SetDisplay(DisplayDummyProxy display) => _display = display;
#endif
}