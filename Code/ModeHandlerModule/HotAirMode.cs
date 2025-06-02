using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class HotAirMode : BaseModeStrategy
{
    public HotAirMode()
        : base(new List<IThermalController>
        {
            RearHeater.GetInstance(),
            Ventilator.GetInstance()
        })
    {
    }
}
