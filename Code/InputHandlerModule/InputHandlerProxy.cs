using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Stellt eine Proxyschicht bereit, um Eingaben zu lesen und zu protokollieren.
    /// </summary>
    public class InputHandlerProxy
    {
        private readonly InputHandler _inputHandler = new InputHandler();
        private readonly Logger _logger = LoggingHandler.Instance.GetLoggerForModule("InputHandler");

        /// <summary>
        /// Liest Eingaben vom Benutzer und schreibt sie ins Log.
        /// </summary>
        /// <returns>Ein <see cref="InputValues"/>-Objekt mit aktuellen Eingabewerten.</returns>
        public InputValues ReadInputs()
        {
            InputValues inputValues = _inputHandler.ReadInputs();
            _logger.Info($"Target Temperature: {inputValues.Temperature} | CookingMode: {inputValues.Mode} | Timer: {inputValues.Timer}");
            return inputValues;
        }
    }
}