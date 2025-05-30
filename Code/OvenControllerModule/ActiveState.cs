using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class ActiveState : IState
{
    public void Run(OvenController context)
    {
        context.GetModeController().Run(context.GetInput());
    }
}