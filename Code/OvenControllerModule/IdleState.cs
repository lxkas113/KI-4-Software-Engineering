using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class IdleState : IState
{
    private InputValues _input;
    
    public void Run(OvenController context, InputValues input)
    {
        _input = input;
        if (CheckStateTransition(context))
        {
            return;
        }
        
        context.GetModeController().Run(_input);
        var output = new OutputValues(
            0,
            false,
            new TimeSpan(0),
            false
        );
        context.GetDisplay().Update(output);
    }

    public bool CheckStateTransition(OvenController context)
    {
        if (_input.Temperature > 0)
        {
            context.SetState(new PreHeatingState());
            return true;
        }
        return false;
    }
}