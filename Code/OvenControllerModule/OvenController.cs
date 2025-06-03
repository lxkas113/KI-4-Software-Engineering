using OvenProject.GlobalModels;
using OvenProject.InputHandlerModule;
using OvenProject.SensorModule;
using OvenProject.ModeHandlerModule;
using OvenProject.OutputHandlerModule;
using OvenProject.SafetyModule;

namespace OvenProject.OvenControllerModule;

public class OvenController
{
    private IState _currentState;
    private TemperatureSensor _tempSensor;
    private DoorSensor _doorSensor;
    private ModeControllerProxy _modeController;
    private InputHandlerProxy _inputHandler;
    private DisplayDummyProxy _display;
    private SafetyHandler _safetyHandler;
    private bool _errorSet = false;

    public OvenController()
    {
        #if DEBUG
        Console.WriteLine("DEBUG aktiv");
        #else
        Console.WriteLine("DEBUG nicht aktiv");
        #endif
        _inputHandler = new InputHandlerProxy();
        _modeController = new ModeControllerProxy();
        _currentState = new StateProxy(new IdleState());
        _tempSensor = new TemperatureSensor();
        _doorSensor = new DoorSensor();
        _display = new DisplayDummyProxy();
        
        _safetyHandler = new SafetyHandler(new List<ISafetyRule>
        {
            new SafetyRuleProxy(new OverheatRule(_tempSensor, this), this),
            new SafetyRuleProxy(new DoorOpenRule(_doorSensor, this), this),
            new SafetyRuleProxy(new HeaterFailureRule(_tempSensor, this), this)
        });

        _safetyHandler.Start();
    }

    public void SetState(IState newState)
    {
        if (_errorSet)
        {
            return;
        }

        if (newState is ErrorState)
        {
            _errorSet = true;
        }
        _currentState = new StateProxy(newState);
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
    
    public IState GetCurrentState() => _currentState;
    
    public void Loop()
    {
        for (int i = 0; i < 10; i++)
        {
            Run();
        }
    }
    
    #if DEBUG
    public InputValues GetInput() => _inputHandler.ReadInputs();
    #endif
    
    #if DEBUG
    public void SetModeController(ModeControllerProxy modeController) => _modeController = modeController;
    #endif
    
    #if DEBUG
    public void SetDisplay(DisplayDummyProxy display) => _display = display;
    #endif
    
    #if DEBUG
    public TemperatureSensor GetTempSensor() => _tempSensor;
    #endif
    
    #if DEBUG
    public DoorSensor GetDoorSensor() => _doorSensor;
    #endif
}