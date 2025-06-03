using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule
{
    /// <summary>
    /// Repräsentiert den Leerlaufzustand des Ofens, wenn keine Temperatur gesetzt ist.
    /// </summary>
    public class IdleState : IState
    {
        private InputValues _input;

        /// <inheritdoc />
        public void Run(OvenController context, InputValues input)
        {
            _input = input;
            if (CheckStateTransition(context)) return;

            context.GetModeController().Run(_input);
            var output = new OutputValues(0, false, TimeSpan.Zero, false);
            context.GetDisplay().Update(output);
        }

        /// <inheritdoc />
        public bool CheckStateTransition(OvenController context)
        {
            if (_input.Temperature > 0)
            {
                context.SetState(new PreHeatingState());
                return true;
            }
            return false;
        }
    }
}