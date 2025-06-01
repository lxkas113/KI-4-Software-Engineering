using NLog;
using OvenProject.GlobalModels;
using OvenProject.LogginModule;

namespace OvenProject.InputHandlerModule;

public class InputHandlerProxy
{
    private readonly InputHandler _inputHandler = new InputHandler();
    private readonly Logger _logger = LoggingHandler.Instance.GetLoggerForModule("InputHandler");

    public InputValues ReadInputs()
    {
        InputValues inputValues = _inputHandler.ReadInputs();
        _logger.Info($"Target Temperature: {inputValues.Temperature} | CookingMode: {inputValues.Mode} | Timer: {inputValues.Timer}");
        return inputValues;
    }
}