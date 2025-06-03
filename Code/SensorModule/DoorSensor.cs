namespace OvenProject.SensorModule
{
    /// <summary>
    /// Simulierter Türsensor, der meldet, ob die Ofentür geöffnet ist.
    /// </summary>
    public class DoorSensor(bool open = false) : ISensor<bool>
    {
        private bool _isDoorOpen = open;

        /// <summary>
        /// Gibt zurück, ob die Tür geöffnet ist.
        /// </summary>
        /// <returns>True, wenn die Tür geöffnet ist, andernfalls false.</returns>
        public bool GetValue()
        {
            return _isDoorOpen;
        }

        /// <summary>
        /// Setzt den Türstatus (geöffnet oder geschlossen).
        /// </summary>
        /// <param name="open">True, wenn die Tür geöffnet ist.</param>
        public void SetDoorState(bool open)
        {
            _isDoorOpen = open;
        }

#if DEBUG
        /// <summary>
        /// Setzt den Türstatus (nur für Tests im Debug-Modus).
        /// </summary>
        public void SetDoorValue(bool open) => _isDoorOpen = open;
#endif
    }
}