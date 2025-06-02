using OvenProject.ModeHandlerModule;
using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class TopHeatMode : BaseModeStrategy
{
    public TopHeatMode()
        : base(new List<IThermalController>
        {
            TopHeater.GetInstance()
        })
    {
    }
}