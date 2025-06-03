namespace OvenProject.GlobalModels
{
    /// <summary>
    /// Gibt die verfügbaren Kochmodi für den Ofen an.
    /// </summary>
    public enum CookingMode
    {
        /// <summary>
        /// Der Ofen ist aktiv aber führt keine Heizfunktion aus.
        /// </summary>
        Idle,

        /// <summary>
        /// Heizt gleichzeitig von oben und unten.
        /// </summary>
        TopBottomHeat,

        /// <summary>
        /// Heizt nur von oben.
        /// </summary>
        TopHeat,

        /// <summary>
        /// Heizt nur von unten.
        /// </summary>
        BottomHeat,

        /// <summary>
        /// Aktiviert die Grillfunktion.
        /// </summary>
        Grill,

        /// <summary>
        /// Heizt oben und unten und nutzt einen Ventilator zur Umwälzung heißer Luft.
        /// </summary>
        CirculatingAir,

        /// <summary>
        /// Heißluftbetrieb mit Ringheizkörper und Ventilator.
        /// </summary>
        HotAir,
        
        #if DEBUG
        /// <summary>
        /// Modus fürs Testen
        /// </summary>
        Heat,
        #endif
    }
}