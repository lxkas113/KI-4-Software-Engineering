namespace OvenProject.SafetyModule;

public class SafetyHandler
{
    private readonly List<ISafetyRule> _rules;
    private Thread _thread;
    private bool _running;

    public SafetyHandler(IEnumerable<ISafetyRule> rules)
    {
        _rules = rules.ToList();
    }

    public void Start()
    {
        _running = true;
        _thread = new Thread(SafetyLoop) { IsBackground = true };
        _thread.Start();
    }

    public void Stop()
    {
        _running = false;
        _thread?.Join();
    }

    private void SafetyLoop()
    {
        while (_running)
        {
            foreach (var rule in _rules)
            {
                rule.Check();
            }
            Thread.Sleep(500);
        }
    }
}
