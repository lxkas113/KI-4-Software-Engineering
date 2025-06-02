using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class BottomHeatMode : BaseModeStrategy
{
    public BottomHeatMode()
        : base(new List<IThermalController>
        {
            BottomHeater.GetInstance()
        })
    {
    }
}