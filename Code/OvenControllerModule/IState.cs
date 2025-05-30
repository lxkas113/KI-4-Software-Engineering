namespace OvenProject.OvenControllerModule;

public interface IState
{
    void Run(OvenController context);
}