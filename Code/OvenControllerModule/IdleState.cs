using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class IdleState : IState
{
    private InputValues _input;
    
    public void Run(OvenController context, InputValues input)
    {
        _input = input;
        CheckStateTransition(context);
        
        context.GetModeController().Run(input);
        var output = new OutputValues(
            0,
            false,
            new TimeSpan(0),
            false
        );
        context.GetDisplay().Update(output);
    }

    public void CheckStateTransition(OvenController context)
    {
        if (_input.Temperature > 0)
        {
            context.SetState(new PreHeatingState());
        }
    }
}