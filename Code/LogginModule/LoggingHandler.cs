using NLog;
using NLog.Config;
using NLog.Targets;

namespace OvenProject.LogginModule
{
    /// <summary>
    /// Singleton-Klasse zur zentralen Konfiguration und Verwaltung von Logger-Instanzen mit NLog.
    /// </summary>
    public class LoggingHandler
    {
        private static readonly Lazy<LoggingHandler> instance = new(() => new LoggingHandler());
        private static readonly object Padlock = new();

        private readonly string _containerName;
        private readonly LoggingConfiguration _config;
        private static readonly HashSet<string> RegisteredLoggerNames = new();

        /// <summary>
        /// Privater Konstruktor, der die Logging-Konfiguration initialisiert.
        /// </summary>
        private LoggingHandler()
        {
            _containerName = Environment.GetEnvironmentVariable("CONTAINER_NAME") ?? "OvenProject";
            _containerName = _containerName.Replace(" ", "_");

            _config = new LoggingConfiguration();

            var consoleTarget = new ConsoleTarget("logconsole")
            {
                Layout = "${longdate} | ${logger} | [${level}] | ${message}"
            };

            _config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
            LogManager.Configuration = _config;

            var initLogger = LogManager.GetLogger($"{_containerName}.init");
            RegisterLogger(initLogger);

            initLogger.Info("Logger system initialized");
        }

        /// <summary>
        /// Gibt die Singleton-Instanz des LoggingHandlers zurück.
        /// </summary>
        public static LoggingHandler Instance => instance.Value;

        /// <summary>
        /// Gibt einen Logger für das angegebene Modul zurück. Er wird automatisch registriert, wenn er noch nicht vorhanden ist.
        /// </summary>
        /// <param name="moduleName">Der Name des Moduls, für das ein Logger benötigt wird.</param>
        /// <returns>Ein <see cref="Logger"/> für das angegebene Modul.</returns>
        public Logger GetLoggerForModule(string moduleName)
        {
            var fullName = $"{_containerName}.{moduleName}";

            lock (Padlock)
            {
                if (!RegisteredLoggerNames.Contains(fullName))
                {
                    RegisteredLoggerNames.Add(fullName);
                }

                return LogManager.GetLogger(fullName);
            }
        }

        /// <summary>
        /// Registriert einen Logger intern, um doppelte Instanzen zu vermeiden.
        /// </summary>
        /// <param name="logger">Der zu registrierende <see cref="Logger"/>.</param>
        private void RegisterLogger(Logger logger)
        {
            lock (Padlock)
            {
                if (!RegisteredLoggerNames.Contains(logger.Name))
                {
                    RegisteredLoggerNames.Add(logger.Name);
                }
            }
        }
    }
}
