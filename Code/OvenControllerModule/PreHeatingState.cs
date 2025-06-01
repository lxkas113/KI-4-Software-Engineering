using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public class PreHeatingState : IState
{
    private bool _stillPreheating = true;
    private InputValues _input;
    
    public void Run(OvenController context, InputValues input)
    {
        _input = input;
        _stillPreheating = context.GetModeController().Run(_input);

        var output = new OutputValues(
            context.GetTemperature(),
            _stillPreheating,
            _input.Timer,
            false
        );

        context.GetDisplay().Update(output);
        
        CheckStateTransition(context);
    }

    public void CheckStateTransition(OvenController context)
    {
        if (_input.Temperature == 0)
        {
            context.SetState(new IdleState());
            return;
        }
        if (!_stillPreheating)
        {
            context.SetState(new ActiveState());
        }
    }
    
    #if DEBUG
    public void SetStillPreheating(bool stillPreheating) => _stillPreheating = stillPreheating;
    #endif
    
    #if DEBUG
    public bool IsStillPreheating() => _stillPreheating;
    #endif

    #if DEBUG
    public void SetInput(InputValues input) => _input = input;
    #endif
}