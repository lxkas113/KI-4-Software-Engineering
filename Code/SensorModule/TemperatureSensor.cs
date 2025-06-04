using OvenProject.ThermalControllerModule;

namespace OvenProject.SensorModule
{
    /// <summary>
    /// Sensor zur Ermittlung der höchsten Temperatur aus mehreren Heizquellen.
    /// </summary>
    public class TemperatureSensor : ISensor<int>
    {
        private int _temperature = 0;
        #if  DEBUG
        public bool ModulTest = true;
        #endif
        
        private List<ITemperatureSource> _tempSources = new()
        {
            TopHeater.GetInstance(),
            RearHeater.GetInstance(),
            BottomHeater.GetInstance()
        };

        /// <summary>
        /// Gibt die aktuell gemessene Temperatur zurück.
        /// </summary>
        /// <returns>Die höchste gemessene Temperatur aller Quellen.</returns>
        public int GetValue()
        {
#if DEBUG
            if (ModulTest)
            {
               return _temperature; 
            }
#endif
            UpdateTemperature();
            return _temperature;
        }

        /// <summary>
        /// Aktualisiert die Temperatur basierend auf allen verfügbaren Heizquellen.
        /// </summary>
        public void UpdateTemperature()
        {
            int maxTemp = 0;
            foreach (ITemperatureSource tempSource in _tempSources)
            {
                int currentTemp = tempSource.Temperature;
                if (currentTemp > maxTemp)
                {
                    maxTemp = currentTemp;
                }
            }
            _temperature = maxTemp;
        }

#if DEBUG
        /// <summary>
        /// Setzt eine manuelle Temperatur (nur im Debug-Modus).
        /// </summary>
        public void SetTemperature(int temperature) => _temperature = temperature;
        
        /// <summary>
        /// Setzt den boolean Wert, ob der aktuelle Test ein Modultest oder ein Integrationstest ist.
        /// </summary>
        /// <param name="modultest">true wenn Modultest, false wenn Integrationstest</param>
        public void SetModultest(bool modultest) => ModulTest = modultest;
#endif
    }
}