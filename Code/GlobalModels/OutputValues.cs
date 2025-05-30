namespace OvenProject.GlobalModels;

public class OutputValues
{
    public double Temperature { get; set; }
    public bool PreheatStatus { get; set; }
    public TimeSpan Timer { get; set; }
    public bool Warning { get; set; }
    
    public OutputValues(double temperature, bool preheatStatus, TimeSpan timer, bool warning)
    {
        Temperature = temperature;
        PreheatStatus = preheatStatus;
        Timer = timer;
        Warning = warning;
    }
}