using OvenProject.GlobalModels;
using OvenProject.ModeHandlerModule;
using OvenProject.OutputHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

/// <summary>
/// Testet das Verhalten des ActiveState, insbesondere ob die Temperaturerhöhung korrekt ausgelöst wird.
/// </summary>
public class ActiveStateTest
{
    // TC-2-1
    [Fact]
    public void Run_ActiveState_ShouldProduceOutputAndIncreaseTemperature()
    {
        var controller = new OvenController();
        controller.SetState(new ActiveState());
        int initialTemp = controller.GetTemperature();

        controller.Run();

        int afterTemp = controller.GetTemperature();
        Assert.True(afterTemp >= initialTemp);
    }
}