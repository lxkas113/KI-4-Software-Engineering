namespace OvenProject.SensorModule
{
    public class DoorSensor(bool closed = true) : ISensor<bool>
    {
        private bool _isDoorClosed = closed;

        public bool GetValue()
        {
            return _isDoorClosed;
        }

        public void SetDoorState(bool closed)
        {
            _isDoorClosed = closed;
        }
    }
}