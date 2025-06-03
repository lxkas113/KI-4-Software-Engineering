namespace OvenProject.InputHandlerModule
{
    /// <summary>
    /// Definiert die Schnittstelle für einen generischen Drehregler-Controller.
    /// </summary>
    /// <typeparam name="T">Der Typ des zurückgegebenen Eingabewerts.</typeparam>
    public interface IRotaryController<T>
    {
        /// <summary>
        /// Liest den aktuell ausgewählten Eingabewert aus dem Drehregler.
        /// </summary>
        /// <returns>Der ausgelesene Wert vom Typ T.</returns>
        T ReadInput();
    }
}