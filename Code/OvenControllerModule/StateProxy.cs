using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.OvenControllerModule
{
    /// <summary>
    /// Ein Proxy für die Implementierung von <see cref="IState"/>, der zusätzliche Logging-Funktionalität bietet.
    /// Protokolliert jeden Aufruf des Zustands zur besseren Nachvollziehbarkeit der Abläufe im Ofencontroller.
    /// </summary>
    public class StateProxy : IState
    {
        private readonly IState _innerState;
        private readonly Logger _logger;

        /// <summary>
        /// Erstellt eine neue Instanz des <see cref="StateProxy"/> mit dem gegebenen Zustand und initialisiert den Logger.
        /// </summary>
        /// <param name="innerState">Der tatsächliche Zustand, der ausgeführt werden soll.</param>
        public StateProxy(IState innerState)
        {
            _innerState = innerState;
            _logger = LoggingHandler.Instance.GetLoggerForModule("OvenController");
        }

        /// <summary>
        /// Führt die Logik des aktuellen Zustands aus und schreibt zusätzlich den Zustand auf die Konsole.
        /// </summary>
        /// <param name="context">Der aktuelle Kontext des Ofencontrollers.</param>
        /// <param name="input">Die aktuellen Eingabewerte für den Zustand.</param>
        public void Run(OvenController context, InputValues input)
        {
            _logger.Info($"Current OvenController State: {GetStateName()}");
            _innerState.Run(context, input);
        }

        /// <inheritdoc />
        public bool CheckStateTransition(OvenController context)
        {
            return _innerState.CheckStateTransition(context);
        }

        /// <summary>
        /// Gibt den Namen des aktuellen internen Zustands zurück.
        /// </summary>
        /// <returns>Der Klassenname des inneren Zustandsobjekts.</returns>
        private string GetStateName() => _innerState.GetType().Name;

        /// <summary>
        /// Gibt den gekapselten Zustand zurück.
        /// </summary>
        /// <returns>Die aktuelle <see cref="IState"/>-Instanz.</returns>
        public IState GetState() => _innerState;
    }
}