using OvenProject.OvenControllerModule;

namespace OvenProject;

/// <summary>
/// Einstiegspunkt für das Ofensteuerungsprogramm.
/// Initialisiert den <see cref="OvenController"/> und startet dessen Hauptschleife.
/// </summary>
class Program
{
    /// <summary>
    /// Hauptmethode der Anwendung. Wird beim Start des Programms aufgerufen.
    /// </summary>
    /// <param name="args">Kommandozeilenargumente (werden aktuell nicht verwendet).</param>
    static void Main(string[] args)
    {
        OvenController controller = new OvenController();
        controller.Loop();
    }
}d