namespace OvenProject.GlobalModels;

public class OutputValues
{
    public double Temperature { get; set; }
    public bool PreheatStatus { get; set; }
    public TimeSpan Timer { get; set; }
    public bool Warning { get; set; }
}