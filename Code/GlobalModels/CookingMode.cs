namespace OvenProject.GlobalModels
{
    /// <summary>
    /// Gibt die verfügbaren Kochmodi für den Ofen an.
    /// </summary>
    public enum CookingMode
    {
        /// <summary>
        /// Der Ofen ist inaktiv und führt keine Heizfunktion aus.
        /// </summary>
        Idle,

        /// <summary>
        /// Heizt gleichzeitig von oben und unten – ideal zum gleichmäßigen Backen.
        /// </summary>
        TopBottomHeat,

        /// <summary>
        /// Heizt nur von oben – geeignet zum Überbacken oder Bräunen.
        /// </summary>
        TopHeat,

        /// <summary>
        /// Heizt nur von unten – nützlich für Speisen mit empfindlicher Oberseite.
        /// </summary>
        BottomHeat,

        /// <summary>
        /// Aktiviert die Grillfunktion – ideal zum Grillen von Fleisch oder Gratins.
        /// </summary>
        Grill,

        /// <summary>
        /// Nutzt einen Ventilator zur Umwälzung heißer Luft – sorgt für gleichmäßige Hitzeverteilung.
        /// </summary>
        CirculatingAir,

        /// <summary>
        /// Heißluftbetrieb mit Ringheizkörper und Ventilator – effizient zum Backen auf mehreren Ebenen.
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