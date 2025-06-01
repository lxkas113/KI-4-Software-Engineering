using OvenProject.GlobalModels;

namespace OvenProject.ModeHandlerModule;

public class ModeController
{
    private IModeStrategy _currentStrategy;

    public bool Run(InputValues input)
    {
        _currentStrategy = CreateStrategyForMode(input.Mode);
        return _currentStrategy.Run(input.Temperature);
    }

    private IModeStrategy CreateStrategyForMode(CookingMode mode)
    {
        return new DefaultMode();
    }
}