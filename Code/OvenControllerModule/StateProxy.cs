using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.OvenControllerModule
{
    /// <summary>
    /// Proxy für IState mit Logging der aktuellen Zustände.
    /// </summary>
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

        public IState GetState() => _innerState;
    }
}