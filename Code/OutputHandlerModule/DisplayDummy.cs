using OvenProject.GlobalModels;

namespace OvenProject.OutputHandlerModule;

public class DisplayDummy
{
    public double Temperature { get; private set; }
    public bool PreheatStatus { get; private set; }
    public TimeSpan Timer { get; private set; }
    public bool Warning { get; private set; }

    public void Update(OutputValues outputValues)
    {
        Temperature = outputValues.Temperature;
        PreheatStatus = outputValues.PreheatStatus;
        Timer = outputValues.Timer;
        Warning = outputValues.Warning;

        PrintStatus();
    }

    private void PrintStatus()
    {
        Console.WriteLine("===== Display =====");
        Console.WriteLine($"Temperature: {Temperature}°C");
        Console.WriteLine($"Preheat: {(PreheatStatus ? "Yes" : "No")}");
        Console.WriteLine($"Timer: {Timer:mm\\:ss}");
        Console.WriteLine($"Warning: {(Warning ? "⚠️ Yes" : "No")}");
        Console.WriteLine("====================");
    }
}