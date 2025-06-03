namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Implementiert die Zeiteingabe für den Ofenbetrieb.
    /// </summary>
    public class TimerInput : ITimerInput
    {
        private DateTime? _endTime = null;

        /// <inheritdoc />
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
        /// <summary>
        /// Setzt eine Testdauer im Debug-Modus.
        /// </summary>
        /// <param name="duration">Die zu simulierende Zeitdauer.</param>
        public void DebugSetTimer(TimeSpan duration)
        {
            _endTime = DateTime.Now + duration;
        }
#endif
    }
}