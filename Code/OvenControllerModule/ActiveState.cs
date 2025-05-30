using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class ActiveState : IState
{
    public void Run(OvenController context)
    {
        context.GetModeController().Run(context.GetInput());
        var output = new OutputValues(
            context.GetTemperature(),
            false,
            new TimeSpan(0),
            false
        );
        context.GetDisplay().Update(output);
    }
}