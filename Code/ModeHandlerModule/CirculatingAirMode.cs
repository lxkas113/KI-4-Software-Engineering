using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class CirculatingAirMode : BaseModeStrategy
{
    public CirculatingAirMode()
        : base(new List<IThermalController>
        {
            TopHeater.GetInstance(),
            BottomHeater.GetInstance(),
            Ventilator.GetInstance()
        })
    {
    }
}
