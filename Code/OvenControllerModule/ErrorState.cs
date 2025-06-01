using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class ErrorState : IState
{
    public void Run(OvenController context, InputValues input)
    {
        context.GetModeController().Run(input);
        var output = new OutputValues(
            0,
            false,
            new TimeSpan(0),
            true
        );
        context.GetDisplay().Update(output);
    }

    public void CheckStateTransition(OvenController context)
    {
        
    }
}