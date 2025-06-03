﻿using OvenProject.GlobalModels;

namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Interpretiert den Winkel eines Drehreglers zur Auswahl des Backmodus.
    /// </summary>
    public class ModeRotaryController : BaseRotaryController<CookingMode>
    {
        /// <summary>
        /// Liest den eingestellten Kochmodus basierend auf dem aktuellen Winkel.
        /// </summary>
        /// <returns>Ein <see cref="CookingMode"/>-Wert.</returns>
        public override CookingMode ReadInput()
        {
            return GetModuloAngle() switch
            {
                0   => CookingMode.Idle,
                50  => CookingMode.TopBottomHeat,
                100 => CookingMode.TopHeat,
                150 => CookingMode.BottomHeat,
                200 => CookingMode.Grill,
                250 => CookingMode.CirculatingAir,
                300 => CookingMode.HotAir,
                _   => CookingMode.Idle
            };
        }

#if DEBUG
        /// <summary>
        /// Setzt den Winkel für Testzwecke im Debug-Modus.
        /// </summary>
        /// <param name="angle">Der zu setzende Testwinkel.</param>
        public void SetTestAngle(int angle)
        {
            Angle = angle;
        }
#endif
    }
}

