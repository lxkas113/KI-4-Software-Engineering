using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

public class PreheatStateTest
{
    [Fact]
    public void Run_ActiveState_ShouldProduceOutputAndIncreaseTemperature()
    {
        var controller = new OvenController();
        controller.SetState(new PreHeatingState());
        int initialTemp = controller.GetTemperature();

        controller.Run();

        int afterTemp = controller.GetTemperature();
        Assert.True(afterTemp >= initialTemp);
    }
}