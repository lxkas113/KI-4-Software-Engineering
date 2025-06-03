using NLog;
using NLog.Config;
using NLog.Targets;

namespace OvenProject.LogginModule;

public class LoggingHandler
{
    private static readonly Lazy<LoggingHandler> instance = new(() => new LoggingHandler());
    private static readonly object Padlock = new();

    private readonly string _containerName;
    private readonly LoggingConfiguration _config;
    private static readonly HashSet<string> RegisteredLoggerNames = new();

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

    public static LoggingHandler Instance => instance.Value;

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