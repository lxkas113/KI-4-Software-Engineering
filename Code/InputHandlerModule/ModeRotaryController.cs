using OvenProject.GlobalModels;

namespace OvenProject.InputHandlerModule;

public class ModeRotaryController : BaseRotaryController<CookingMode>
{
    public override CookingMode ReadInput()
    {
        int step = GetModuloAngle() / 50;
        return step switch
        {
            0 => CookingMode.Idle,
            1 => CookingMode.TopBottomHeat,
            2 => CookingMode.TopHeat,
            3 => CookingMode.BottomHeat,
            4 => CookingMode.Grill,
            5 => CookingMode.CirculatingAir,
            6 => CookingMode.HotAir,
            _ => CookingMode.Idle
        };
    }
    
    #if DEBUG
    public void SetTestAngle(int angle) // optional für Tests
    {
        Angle = angle;
    }
    #endif
}
