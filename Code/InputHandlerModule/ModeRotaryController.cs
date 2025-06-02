using OvenProject.GlobalModels;

namespace OvenProject.InputHandlerModule;

public class ModeRotaryController : BaseRotaryController<CookingMode>
{
    public override CookingMode ReadInput()
    {
        return GetModuloAngle() switch
        {
            0   => CookingMode.Idle,
            50  => CookingMode.TopBottomHeat,
            100 => CookingMode.TopHeat,
            150 => CookingMode.BottomHeat,
            200 => CookingMode.Grill,
            250 => CookingMode.CirculatingAir,
            300 => CookingMode.HotAir,
            _   => CookingMode.Idle
        };
    }
    
    #if DEBUG
    public void SetTestAngle(int angle) // optional für Tests
    {
        Angle = angle;
    }
    #endif
}
