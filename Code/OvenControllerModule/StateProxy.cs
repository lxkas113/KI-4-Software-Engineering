using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;
using OvenProject.SensorModule;

namespace OvenProject.OvenControllerModule;

public class StateProxy : IState
{
    private readonly IState _innerState;
    private readonly Logger _logger;

    public StateProxy(IState innerState)
    {
        _innerState = innerState;
        _logger = LoggingHandler.Instance.GetLoggerForModule("OvenController");
    }

    public void Run(OvenController context, InputValues input)
    {
        _logger.Info($"Current OvenController State: {GetStateName()}");
        _innerState.Run(context, input);
    }

    public bool CheckStateTransition(OvenController context)
    {
        return _innerState.CheckStateTransition(context);
    }

    private string GetStateName() => _innerState.GetType().Name;
    
    #if DEBUG
    public IState GetState() => _innerState;
    #endif
}