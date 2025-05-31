namespace OvenProject.InputHandlerModule;

public abstract class BaseRotaryController<T> : IRotaryController<T>
{
    public int Angle { get; set; } = 200;

    protected int GetModuloAngle()
    {
        return Angle % 360;
    }

    public abstract T ReadInput();
}