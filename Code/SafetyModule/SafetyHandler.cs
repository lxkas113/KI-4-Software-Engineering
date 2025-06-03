namespace OvenProject.SafetyModule
{
    /// <summary>
    /// Führt alle registrierten Sicherheitsregeln in einem separaten Thread regelmäßig aus.
    /// </summary>
    public class SafetyHandler
    {
        private readonly List<ISafetyRule> _rules;
        private Thread _thread;
        private bool _running;

        /// <summary>
        /// Initialisiert den Handler mit einer Liste von Sicherheitsregeln.
        /// </summary>
        public SafetyHandler(IEnumerable<ISafetyRule> rules)
        {
            _rules = rules.ToList();
        }

        /// <summary>
        /// Startet die Ausführung der Sicherheitsregeln im Hintergrundthread.
        /// </summary>
        public void Start()
        {
            _running = true;
            _thread = new Thread(SafetyLoop) { IsBackground = true };
            _thread.Start();
        }

        /// <summary>
        /// Stoppt die Ausführung der Sicherheitsprüfungen.
        /// </summary>
        public void Stop()
        {
            _running = false;
            _thread?.Join();
        }

        /// <summary>
        /// Interne Schleife zur periodischen Prüfung aller Regeln.
        /// </summary>
        private void SafetyLoop()
        {
            while (_running)
            {
                foreach (var rule in _rules)
                {
                    rule.Check();
                }
                Thread.Sleep(500);
            }
        }
    }
}