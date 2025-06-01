using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.ModeHandlerModule;

public class ModeControllerProxy
{
    private readonly ModeController _controller = new ModeController();
    private readonly Logger _logger = LoggingHandler.Instance.GetLoggerForModule("ModeController");

    public bool Run(InputValues input)
    {
        _logger.Info($"{input.Mode} toggles to {input.Temperature}");
        return _controller.Run(input);
    }
}