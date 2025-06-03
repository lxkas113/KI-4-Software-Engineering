using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.OutputHandlerModule
{
    /// <summary>
    /// Proxyklasse für <see cref="DisplayDummy"/>, erweitert um Logging-Funktionalität.
    /// </summary>
    public class DisplayDummyProxy
    {
        private readonly DisplayDummy _displayDummy = new DisplayDummy();
        private readonly Logger _logger = LoggingHandler.Instance.GetLoggerForModule("Display");

        /// <summary>
        /// Protokolliert die neuen Werte und aktualisiert anschließend das Display.
        /// </summary>
        /// <param name="outputValues">Die neuen Ausgabewerte für das Display.</param>
        public virtual void Update(OutputValues outputValues)
        {
            _logger.Info($"""
                          Display update:
                              Current Temperature: {outputValues.Temperature}
                              Preheat:     {outputValues.PreheatStatus}
                              Timer:       {outputValues.Timer:c}
                              Warning:     {outputValues.Warning}
                          """);
            _displayDummy.Update(outputValues);
        }

#if DEBUG
        /// <summary>
        /// Gibt die interne DisplayDummy-Instanz zurück (nur für Debug-Zwecke).
        /// </summary>
        public DisplayDummy GetDisplayDummy()
        {
            return _displayDummy;
        }
#endif
    }
}