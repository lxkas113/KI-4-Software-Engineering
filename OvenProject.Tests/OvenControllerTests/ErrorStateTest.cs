using OvenProject.GlobalModels;
using OvenProject.OutputHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

public class ErrorStateTest
{
    public class FakeDisplay : DisplayDummyProxy
    {
        public OutputValues? LastOutput { get; private set; }

        public override void Update(OutputValues output)
        {
            LastOutput = output;
        }
    }
    
    [Fact]
    public void ErrorState_ShouldSetWarningTrueInDisplay()
    {
        var controller = new OvenController();
        controller.SetState(new ErrorState());

        var fakeDisplay = new FakeDisplay();
        controller.SetDisplay(fakeDisplay);
        Assert.IsType<FakeDisplay>(controller.GetDisplay());
        
        var input = new InputValues
        {
            Temperature = 0,
            Mode = CookingMode.Heat,
            Timer = TimeSpan.Zero
        };
    
        controller.GetCurrentState().Run(controller, input);

        Assert.NotNull(fakeDisplay.LastOutput);
        Assert.True(fakeDisplay.LastOutput.Warning);
    }
}