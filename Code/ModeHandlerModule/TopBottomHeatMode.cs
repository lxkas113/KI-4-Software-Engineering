using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class TopBottomHeatMode : BaseModeStrategy
{
    public TopBottomHeatMode()
        : base(new List<IThermalController>
        {
            TopHeater.GetInstance(),
            BottomHeater.GetInstance()
        })
    {
    }
}