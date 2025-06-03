using NLog;
using OvenProject.LogginModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.SafetyModule
{
    /// <summary>
    /// Proxy für Sicherheitsregeln, protokolliert Regelverhalten und Zustandsänderungen.
    /// </summary>
    public class SafetyRuleProxy : ISafetyRule
    {
        private readonly ISafetyRule _realRule;
        private readonly OvenController _oven;
        private readonly Logger _logger;

        /// <summary>
        /// Initialisiert den Proxy mit einer echten Regel und einem Logger.
        /// </summary>
        public SafetyRuleProxy(ISafetyRule realRule, OvenController oven)
        {
            _realRule = realRule;
            _oven = oven;
            _logger = LoggingHandler.Instance.GetLoggerForModule("SafetyModule");
        }

        /// <inheritdoc/>
        public void Check()
        {
            var before = ((StateProxy)_oven.GetCurrentState()).GetState();
            _realRule.Check();
            var after = ((StateProxy)_oven.GetCurrentState()).GetState();

            if (before != after)
            {
                _logger.Error($"{_realRule.GetType().Name} triggered a state change to {after.GetType().Name}");
            }
        }
    }
}