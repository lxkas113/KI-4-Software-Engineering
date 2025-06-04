using OvenProject.GlobalModels;

namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Koordiniert die Erfassung aller Benutzereingaben über Drehregler und Timer.
    /// </summary>
    public class InputHandler
    {
        private readonly TemperatureRotaryController _tempController = new();
        private readonly ModeRotaryController _modeController = new();
        private readonly TimerInput _timerInput = new();

        /// <summary>
        /// Liest die aktuellen Benutzereingaben für Temperatur, Modus und Timer.
        /// </summary>
        /// <returns>Ein <see cref="InputValues"/>-Objekt mit den gesammelten Eingaben.</returns>
        public InputValues ReadInputs()
        {
            return new InputValues
            {
                Temperature = _tempController.ReadInput(),
                Mode = _modeController.ReadInput(),
                Timer = _timerInput.ReadInput()
            };
        }

#if  DEBUG
        /// <summary>
        /// Gibt den Drehregler für den Modus zurück.
        /// </summary>
        /// <returns><see cref="ModeRotaryController"/></returns>
        public ModeRotaryController GetModeController() => _modeController;
        
        /// <summary>
        /// Gibt den Drehregler für die Temperatur zurück.
        /// </summary>
        /// <returns><see cref="TemperatureRotaryController"/></returns>
        public TemperatureRotaryController GetTempController() => _tempController;
#endif
    }
}