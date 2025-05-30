using OvenProject.GlobalModels;

namespace OvenProject.InputHandlerModule;

public class InputHandler
{
    private readonly TemperatureRotaryController _tempController = new();

    public InputValues ReadInputs()
    {
        return new InputValues
        {
            Temperature = _tempController.ReadInput()
        };
    }
}