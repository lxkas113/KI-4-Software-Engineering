namespace OvenProject.InputHandlerModule;

public class TimerInput : ITimerInput
{
    private DateTime? _endTime = null;

    public TimeSpan ReadInput()
    {
        if (_endTime == null)
        {
            return TimeSpan.Zero;
        }

        var remainingTime = (TimeSpan)(_endTime - DateTime.Now);
        if (remainingTime < TimeSpan.Zero)
        {
            return TimeSpan.Zero;
        }
        return remainingTime;
    }

    #if DEBUG
    public void DebugSetTimer(TimeSpan duration)
    {
        _endTime = DateTime.Now + duration;
    }
    #endif
}