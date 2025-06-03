namespace OvenProject.SafetyModule
{
    /// <summary>
    /// Schnittstelle für eine Sicherheitsregel, die regelmäßig überprüft werden soll.
    /// </summary>
    public interface ISafetyRule
    {
        /// <summary>
        /// Führt eine Sicherheitsprüfung durch und leitet ggf. Maßnahmen ein.
        /// </summary>
        void Check();
    }
}