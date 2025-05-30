using OvenProject.GlobalModels;
using OvenProject.ModeHandlerModule;
using OvenProject.OutputHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

public class ActiveStateTest
{
    [Fact]
    public void Run_ActiveState_ShouldProduceOutputAndIncreaseTemperature()
    {
        var controller = new OvenController();
        int initialTemp = controller.GetTemperature();

        controller.Run();

        int afterTemp = controller.GetTemperature();
        Assert.True(afterTemp >= initialTemp);
    }
}