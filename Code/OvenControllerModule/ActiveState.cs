using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class ActiveState : IState
{
    private bool _timerStarted = false;
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
            context.GetTemperature(),
            false,
            new TimeSpan(0),
            false
        );
        context.GetDisplay().Update(output);
    }

    public bool CheckStateTransition(OvenController context)
    {
        if (_input.Temperature == 0)
        {
            context.SetState(new IdleState());
            return true;
        }
        return false;
    }
}