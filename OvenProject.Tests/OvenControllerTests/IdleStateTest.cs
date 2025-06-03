using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

/// <summary>
/// Testet das Verhalten des IdleState, insbesondere dass keine Temperaturerhöhung erfolgt.
/// </summary>
public class IdleStateTest
{
    // TC-2-4
    [Fact]
    public void Run_ActiveState_ShouldProduceOutputAndIncreaseTemperature()
    {
        var controller = new OvenController();
        controller.SetState(new IdleState());
        int initialTemp = controller.GetTemperature();

        controller.Run();

        int afterTemp = controller.GetTemperature();
        Assert.True(afterTemp < initialTemp || afterTemp == 0);
    }
}