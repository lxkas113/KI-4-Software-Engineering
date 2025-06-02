using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public class GrillMode : BaseModeStrategy
{
    public GrillMode()
        : base(new List<IThermalController>
        {
            TopHeater.GetInstance()
        })
    {
    }

    public override bool Run(int targetTemperature)
    {
        return base.Run(CalculateStepTemperature(targetTemperature));
    }

    private int CalculateStepTemperature(int targetTemperature)
    {
        if (targetTemperature >= 300) return 300;
        if (targetTemperature >= 280) return 280;
        if (targetTemperature >= 260) return 260;
        if (targetTemperature >= 240) return 240;
        return 0;
    }
    
    #if DEBUG
    public int CallCalculateStepTemperature(int targetTemperature)
    {
        return CalculateStepTemperature(targetTemperature);
    }
    #endif
}