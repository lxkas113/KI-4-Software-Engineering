using NLog;
using OvenProject.LogginModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.SafetyModule;

public class SafetyRuleProxy : ISafetyRule
{
    private readonly ISafetyRule _realRule;
    private readonly OvenController _oven;
    private readonly Logger _logger;

    public SafetyRuleProxy(ISafetyRule realRule, OvenController oven)
    {
        _realRule = realRule;
        _oven = oven;
        _logger = LoggingHandler.Instance.GetLoggerForModule("SafetyModule");
    }

    public void Check()
    {
        var before = ((StateProxy)_oven.GetCurrentState()).GetState();
        _realRule.Check();
        var after = ((StateProxy)_oven.GetCurrentState()).GetState();

        if (before != after)
        {
            _logger.Error($"{ _realRule.GetType().Name } triggered a state change to {after.GetType().Name}");
        }
    }
}