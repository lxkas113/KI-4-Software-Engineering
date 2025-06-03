using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Proxy für ModeController mit Logging-Funktionalität.
    /// </summary>
    public class ModeControllerProxy
    {
        private ModeController _controller = new ModeController();
        private readonly Logger _logger = LoggingHandler.Instance.GetLoggerForModule("ModeController");

        /// <summary>
        /// Führt den Moduswechsel aus und protokolliert den Vorgang.
        /// </summary>
        /// <param name="input">Eingabewerte vom Benutzer.</param>
        /// <returns>True, wenn noch vorgeheizt wird.</returns>
        public bool Run(InputValues input)
        {
            _logger.Info($"{input.Mode} toggles to {input.Temperature}");
            return _controller.Run(input);
        }

#if DEBUG
        /// <summary>
        /// Setzt den internen ModeController im Debug-Modus.
        /// </summary>
        public void SetModeController(ModeController modeController) => _controller = modeController;
#endif
    }
}