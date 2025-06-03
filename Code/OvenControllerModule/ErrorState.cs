using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule
{
    /// <summary>
    /// Repräsentiert einen Fehlerzustand des Ofens, in dem eine Warnung angezeigt wird.
    /// </summary>
    public class ErrorState : IState
    {
        /// <inheritdoc />
        public void Run(OvenController context, InputValues input)
        {
            context.GetModeController().Run(input);
            var output = new OutputValues(0, false, TimeSpan.Zero, true);
            context.GetDisplay().Update(output);
        }

        /// <inheritdoc />
        public bool CheckStateTransition(OvenController context) => false;
    }
}