namespace OvenProject.SensorModule
{
    public interface ISensor<T>
    {
        T GetValue();
    }
}