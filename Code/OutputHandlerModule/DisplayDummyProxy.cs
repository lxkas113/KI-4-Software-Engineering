using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.OutputHandlerModule;

public class DisplayDummyProxy
{
    private readonly DisplayDummy _displayDummy = new DisplayDummy();
    private readonly Logger _logger = LoggingHandler.Instance.GetLoggerForModule("Display");

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
    public DisplayDummy GetDisplayDummy()
    {
        return _displayDummy;
    }
    #endif
}