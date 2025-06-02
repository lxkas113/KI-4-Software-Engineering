using OvenProject.GlobalModels;

namespace OvenProject.ModeHandlerModule;

public class ModeController
{
    private IModeStrategy _currentStrategy = new IdleMode();
    private CookingMode _currentMode = CookingMode.Idle;

    public bool Run(InputValues input)
    {
        CheckStrategyForMode(input.Mode);
        return _currentStrategy.Run(input.Temperature);
    }

    private void CheckStrategyForMode(CookingMode mode)
    {
        if (mode == _currentMode) return;

        _currentMode = mode;
        _currentStrategy = mode switch
        {
            CookingMode.Idle => new IdleMode(),
            CookingMode.TopBottomHeat => new TopBottomHeatMode(),
            CookingMode.TopHeat => new TopHeatMode(),
            CookingMode.BottomHeat => new BottomHeatMode(),
            CookingMode.Grill => new GrillMode(),
            CookingMode.CirculatingAir => new CirculatingAirMode(),
            CookingMode.HotAir => new HotAirMode(),
            _ => new IdleMode()
        };
    }
    
    #if DEBUG
    public void SetModeStrategy(IModeStrategy Mode) => _currentStrategy = Mode;
    #endif
}