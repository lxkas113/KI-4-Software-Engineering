using OvenProject.GlobalModels;

namespace OvenProject.ModeHandlerModule
{
    /// <summary>
    /// Steuert den aktiven Betriebsmodus und verwaltet den Strategiewechsel.
    /// </summary>
    public class ModeController
    {
        private IModeStrategy _currentStrategy = new IdleMode();
        private CookingMode _currentMode = CookingMode.Idle;

        /// <summary>
        /// Führt die aktuelle Modusstrategie basierend auf den Eingabewerten aus.
        /// </summary>
        /// <param name="input">Eingabewerte vom Benutzer.</param>
        /// <returns>True, wenn noch vorgeheizt wird.</returns>
        public bool Run(InputValues input)
        {
            CheckStrategyForMode(input.Mode);
            return _currentStrategy.Run(input.Temperature);
        }

        /// <summary>
        /// Aktualisiert die Strategie, wenn sich der Modus geändert hat.
        /// </summary>
        /// <param name="mode">Der neue gewünschte Kochmodus.</param>
        private void CheckStrategyForMode(CookingMode mode)
        {
            if (mode == _currentMode) return;

            _currentMode = mode;
            _currentStrategy = mode switch
            {
                CookingMode.Idle => new IdleMode(),
                CookingMode.TopBottomHeat => new TopBottomHeatMode(),
                CookingMode.TopHeat => new TopHeatMode(),
                CookingMode.BottomHeat => new BottomHeatMode(),
                CookingMode.Grill => new GrillMode(),
                CookingMode.CirculatingAir => new CirculatingAirMode(),
                CookingMode.HotAir => new HotAirMode(),
                _ => new IdleMode()
            };
        }

#if DEBUG
        /// <summary>
        /// Erlaubt das manuelle Setzen einer Strategie im Debug-Modus.
        /// </summary>
        public void SetModeStrategy(IModeStrategy Mode) => _currentStrategy = Mode;
#endif
    }
}