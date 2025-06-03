using OvenProject.GlobalModels;

namespace OvenProject.OvenControllerModule
{
    /// <summary>
    /// Zustand für die Vorheizphase des Ofens.
    /// </summary>
    public class PreHeatingState : IState
    {
        private bool _stillPreheating = true;
        private InputValues _input;

        public void Run(OvenController context, InputValues input)
        {
            _input = input;
            _stillPreheating = context.GetModeController().Run(_input);

            var output = new OutputValues(
                context.GetTemperature(),
                _stillPreheating,
                _input.Timer,
                false
            );

            context.GetDisplay().Update(output);
            CheckStateTransition(context);
        }

        public bool CheckStateTransition(OvenController context)
        {
            if (_input.Temperature == 0)
            {
                context.SetState(new IdleState());
                return true;
            }
            if (!_stillPreheating)
            {
                context.SetState(new ActiveState());
                return true;
            }
            return false;
        }

#if DEBUG
        public void SetStillPreheating(bool stillPreheating) => _stillPreheating = stillPreheating;
        public bool IsStillPreheating() => _stillPreheating;
        public void SetInput(InputValues input) => _input = input;
#endif
    }
}