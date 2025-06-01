using OvenProject.GlobalModels;

namespace OvenProject.OutputHandlerModule;

public class DisplayDummy
{
    public int Temperature { get; private set; }
    public bool PreheatStatus { get; private set; }
    public TimeSpan Timer { get; private set; }
    public bool Warning { get; private set; }

    public void Update(OutputValues outputValues)
    {
        Temperature = outputValues.Temperature;
        PreheatStatus = outputValues.PreheatStatus;
        Timer = outputValues.Timer;
        Warning = outputValues.Warning;
    }
}