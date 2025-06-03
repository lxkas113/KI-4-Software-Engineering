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
    }
}