﻿using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Betriebsmodus für Heißluft – verwendet hinteren Heizkörper und Ventilator.
    /// </summary>
    public class HotAirMode : BaseModeStrategy
    {
        /// <summary>
        /// Initialisiert den Heißluftmodus mit hinterem Heizelement und Ventilator.
        /// </summary>
        public HotAirMode()
            : base(new List<IThermalController>
            {
                RearHeater.GetInstance(),
                Ventilator.GetInstance()
            })
        {
        }
    }
}

