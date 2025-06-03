using OvenProject.GlobalModels;
using OvenProject.InputHandlerModule;
using OvenProject.SensorModule;
using OvenProject.ModeHandlerModule;
using OvenProject.OutputHandlerModule;
using OvenProject.SafetyModule;

namespace OvenProject.OvenControllerModule;

/// <summary>
/// Hauptcontroller für den Ofen. Koordiniert Zustände, Eingaben, Ausgaben, Sicherheit und Sensorik.
/// </summary>
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

    /// <summary>
    /// Initialisiert alle Komponenten des Ofens.
    /// </summary>
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

    /// <summary>
    /// Setzt den aktuellen Zustand. Fehlerzustände werden einmalig gesetzt.
    /// </summary>
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
    
    /// <summary>
    /// Führt die Logik des aktuellen Zustands aus.
    /// </summary>
    public void Run()
    {
        _currentState.Run(this, _inputHandler.ReadInputs());
    }

    /// <summary>
    /// Gibt den ModeController zurück, der die Betriebsmodi des Ofens steuert.
    /// </summary>
    public virtual ModeControllerProxy GetModeController() => _modeController;
    
    /// <summary>
    /// Git die aktuelle Temperatur vom Temperatursensor zurück.
    /// </summary>
    public virtual int GetTemperature() => _tempSensor.GetValue();
    
    /// <summary>
    /// Gibt die Displayklasse zurück.
    /// </summary>
    public virtual DisplayDummyProxy GetDisplay() => _display;
    
    /// <summary>
    /// Gibt die Proxyklasse des aktuellen Zustand des Ofens zurück.
    /// </summary>
    public IState GetCurrentState() => _currentState;
    
    /// <summary>
    /// Führt die Steuerlogik in einer Endlosschleife.
    /// </summary>
    public void Loop()
    {
        while(true)
        {
            Run();
        }
    }
    
#if DEBUG
    /// <summary>
    /// Gibt den Input des Users zurück.
    /// </summary>
    public InputValues GetInput() => _inputHandler.ReadInputs();
    
    /// <summary>
    /// Setzt den ModeController, um die Betriebsmodi zu steuern.
    /// </summary>
    public void SetModeController(ModeControllerProxy modeController) => _modeController = modeController;
    
    /// <summary>
    /// Setzt die Display-Klasse.
    /// </summary>
    public void SetDisplay(DisplayDummyProxy display) => _display = display;
    
    /// <summary>
    /// Gibt den Temperatursensor zurück.
    /// </summary>
    public TemperatureSensor GetTempSensor() => _tempSensor;
    
    /// <summary>
    /// Gibt den Türsensor zurück.
    /// </summary>
    public DoorSensor GetDoorSensor() => _doorSensor;
#endif
}