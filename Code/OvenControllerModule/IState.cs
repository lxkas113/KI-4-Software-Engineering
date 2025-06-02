using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule;

public interface IState
{
    void Run(OvenController context, InputValues input);

    bool CheckStateTransition(OvenController context);
}