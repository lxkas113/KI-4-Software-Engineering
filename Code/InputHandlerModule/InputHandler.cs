using OvenProject.GlobalModels;

namespace OvenProject.InputHandlerModule;

public class InputHandler
{
    private readonly TemperatureRotaryController _tempController = new();
    private readonly ModeRotaryController _modeController = new();
    private readonly TimerInput _timerInput = new();

    public InputValues ReadInputs()
    {
        return new InputValues
        {
            Temperature = _tempController.ReadInput(),
            Mode = _modeController.ReadInput(),
            Timer = _timerInput.ReadInput()
        };
    }
}