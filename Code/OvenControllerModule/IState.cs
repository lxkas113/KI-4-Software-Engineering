using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public interface IState
{
    void Run(OvenController context, InputValues input);

    void CheckStateTransition(OvenController context);
}