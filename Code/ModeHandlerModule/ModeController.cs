using OvenProject.GlobalModels;

namespace OvenProject.ModeHandlerModule;

public class ModeController
{
    private IModeStrategy _currentStrategy;

    public void Run(InputValues input)
    {
        _currentStrategy = CreateStrategyForMode(input.Mode);
        _currentStrategy.Run(input.Temperature);
    }

    private IModeStrategy CreateStrategyForMode(CookingMode mode)
    {
        return new DefaultMode();
    }
}