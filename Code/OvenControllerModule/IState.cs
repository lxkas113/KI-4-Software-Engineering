using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule
{
    /// <summary>
    /// Definiert das Interface für einen Zustand im Zustandsautomaten des Ofens.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Führt die Logik des aktuellen Zustands aus.
        /// </summary>
        /// <param name="context">Der Kontext (OvenController), in dem der Zustand ausgeführt wird.</param>
        /// <param name="input">Die vom Benutzer eingegebenen Werte.</param>
        void Run(OvenController context, InputValues input);

        /// <summary>
        /// Prüft, ob ein Zustandswechsel notwendig ist.
        /// </summary>
        /// <param name="context">Der Kontext, in dem der Übergang geprüft wird.</param>
        /// <returns>True, wenn ein Zustandswechsel durchgeführt wurde.</returns>
        bool CheckStateTransition(OvenController context);
    }
}